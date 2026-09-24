using System.Numerics;

namespace War.BattleServer;

public enum ArmyNavMeshConnection { Outside, Disconnected, Connected }
public sealed record ArmyNavMeshCorridor(IReadOnlyList<Vector3> Points,float Length,
    IReadOnlyList<Vector3> SmoothedPoints,float SmoothedLength,bool PlanarCovered,
    float MaxVerticalDeviation);
public sealed record ArmyNavMeshPolylineAudit(bool PlanarCovered,float MaxVerticalDeviation);

/// <summary>Walkable triangle components, not a Unity-equivalent corner path solver.</summary>
public sealed class ArmyNavMeshConnectivity
{
    private readonly IReadOnlyDictionary<string,Graph> maps;
    private readonly ArmyNavMeshPathFixtureCatalog fixtures;
    private ArmyNavMeshConnectivity(Dictionary<string,Graph> maps,
        ArmyNavMeshPathFixtureCatalog fixtures)
    {this.maps=maps;this.fixtures=fixtures;}
    public ArmyNavMeshConnection Classify(RecoveredBattleMap map,Vector3 start,Vector3 end)
        =>maps.TryGetValue(map.Source,out var graph)
            ? graph.Classify(start,end)
            : throw new InvalidDataException("Unknown pinned navigation map.");
    public int ComponentCount(RecoveredBattleMap map)
        =>maps.TryGetValue(map.Source,out var graph)
            ? graph.ComponentCount
            : throw new InvalidDataException("Unknown pinned navigation map.");
    public ArmyNavMeshCorridor? PlanCorridor(RecoveredBattleMap map,Vector3 start,Vector3 end)
        =>maps.TryGetValue(map.Source,out var graph)
            ? graph.PlanCorridor(start,end)
            : throw new InvalidDataException("Unknown pinned navigation map.");
    // An exact source spawn/point pair may follow Unity's pinned CalculatePath
    // corners. A later position or retarget must use the general planner.
    public ArmyNavMeshCorridor? PlanSourceSpawnCorridor(RecoveredBattleMap map,
        int spawnFileId,int rusherFileId,Vector3 start,Vector3 end)
    {
        var fixture=fixtures.ForMap(map).SingleOrDefault(row=>
            row.SpawnFileId==spawnFileId && row.RusherFileId==rusherFileId);
        if(fixture==null || !fixture.Complete)return null;
        if(Vector3.Distance(start,fixture.Start)>.002f ||
           Vector3.Distance(end,fixture.End)>.002f)
            return null;
        var points=new List<Vector3>{start};
        points.AddRange(fixture.Corners.Skip(1).Take(fixture.Corners.Count-2));
        points.Add(end);
        var audit=InspectPolyline(map,points);
        // Source prefab spawn transforms sit slightly above the baked surface.
        if(!audit.PlanarCovered || audit.MaxVerticalDeviation>.35f)return null;
        float length=0;
        for(int i=1;i<points.Count;i++)length+=Vector3.Distance(points[i-1],points[i]);
        if(!float.IsFinite(length) || length<=.04f || length>10000)
            throw new InvalidDataException("Source Rusher route has invalid length.");
        var frozen=Array.AsReadOnly(points.ToArray());
        return new(frozen,length,frozen,length,true,audit.MaxVerticalDeviation);
    }
    public ArmyNavMeshPolylineAudit InspectPolyline(RecoveredBattleMap map,
        IReadOnlyList<Vector3> points)
        =>maps.TryGetValue(map.Source,out var graph)
            ? graph.InspectPolyline(points)
            : throw new InvalidDataException("Unknown pinned navigation map.");
    public Vector3? SampleNearest(RecoveredBattleMap map,Vector3 point,float radius)
        =>maps.TryGetValue(map.Source,out var graph)
            ? graph.SampleNearest(point,radius)
            : throw new InvalidDataException("Unknown pinned navigation map.");

    public static ArmyNavMeshConnectivity Build(IReadOnlyList<RecoveredBattleMap> sourceMaps,
        ArmyNavMeshTriangulationCatalog geometry,ArmyNavMeshPathFixtureCatalog fixtures)
    {
        var graphs=new Dictionary<string,Graph>(StringComparer.Ordinal);
        int checkedRoutes=0;
        foreach(var map in sourceMaps)
        {
            var graph=new Graph(geometry.ForMap(map));
            foreach(var fixture in fixtures.ForMap(map))
            {
                var status=graph.Classify(fixture.SampledStart,fixture.SampledEnd);
                if(status!=(fixture.Complete ? ArmyNavMeshConnection.Connected :
                    ArmyNavMeshConnection.Disconnected))
                    throw new InvalidDataException("Triangle connectivity disagrees with Unity path status: "+
                        map.Source+" "+fixture.SpawnFileId+"-"+fixture.RusherFileId+" "+status+
                        " Unity="+(fixture.Complete?"complete":"partial"));
                checkedRoutes++;
            }
            if(!graphs.TryAdd(map.Source,graph))
                throw new InvalidDataException("Duplicate navigation graph scene.");
        }
        if(graphs.Count!=5 || checkedRoutes!=432)
            throw new InvalidDataException("Incomplete navigation connectivity proof.");
        return new(graphs,fixtures);
    }

    private readonly record struct VertexKey(int X,int Y,int Z) : IComparable<VertexKey>
    {
        public int CompareTo(VertexKey other)
        {
            int first=X.CompareTo(other.X);
            if(first!=0)return first;
            int second=Y.CompareTo(other.Y);
            return second!=0 ? second : Z.CompareTo(other.Z);
        }
        public static VertexKey From(Vector3 value)=>new(
            checked((int)Math.Round(value.X*10000d,MidpointRounding.ToEven)),
            checked((int)Math.Round(value.Y*10000d,MidpointRounding.ToEven)),
            checked((int)Math.Round(value.Z*10000d,MidpointRounding.ToEven)));
    }
    private readonly record struct EdgeKey(VertexKey A,VertexKey B)
    {
        public static EdgeKey Make(VertexKey a,VertexKey b)
            =>a.CompareTo(b)<=0 ? new(a,b) : new(b,a);
    }
    private sealed class Graph
    {
        private readonly record struct Neighbor(int Triangle,Vector3 A,Vector3 B)
        { public Vector3 Portal => (A+B)/2f; }
        private readonly record struct Portal(Vector3 Left,Vector3 Right);
        private readonly IReadOnlyList<Vector3> vertices;
        private readonly IReadOnlyList<int> indices;
        private readonly int[] components;
        private readonly IReadOnlyDictionary<int,int[]> componentTriangles;
        private readonly Vector3[] centroids;
        private readonly List<Neighbor>[] neighbors;
        public int ComponentCount { get; }
        public Graph(ArmyNavMeshTriangulation mesh)
        {
            vertices=mesh.Vertices;indices=mesh.Indices;
            int count=indices.Count/3;
            var parent=Enumerable.Range(0,count).ToArray();
            centroids=new Vector3[count];
            neighbors=Enumerable.Range(0,count).Select(_=>new List<Neighbor>()).ToArray();
            int Root(int triangle)
            {
                while(parent[triangle]!=triangle)
                {parent[triangle]=parent[parent[triangle]];triangle=parent[triangle];}
                return triangle;
            }
            var keys=vertices.Select(VertexKey.From).ToArray();
            var edges=new Dictionary<EdgeKey,(int Triangle,int Count)>();
            for(int triangle=0;triangle<count;triangle++)
            {
                centroids[triangle]=(vertices[indices[triangle*3]]+
                    vertices[indices[triangle*3+1]]+vertices[indices[triangle*3+2]])/3f;
                for(int edge=0;edge<3;edge++)
                {
                    var key=EdgeKey.Make(keys[indices[triangle*3+edge]],
                        keys[indices[triangle*3+(edge+1)%3]]);
                    if(edges.TryGetValue(key,out var existing))
                    {
                        if(existing.Count!=1 || existing.Triangle==triangle)
                            throw new InvalidDataException("Nonmanifold Unity NavMesh edge.");
                        parent[Root(triangle)]=Root(existing.Triangle);
                        var a=vertices[indices[triangle*3+edge]];
                        var b=vertices[indices[triangle*3+(edge+1)%3]];
                        neighbors[triangle].Add(new(existing.Triangle,a,b));
                        neighbors[existing.Triangle].Add(new(triangle,a,b));
                        edges[key]=(existing.Triangle,2);
                    }
                    else edges.Add(key,(triangle,1));
                }
            }
            components=Enumerable.Range(0,count).Select(Root).ToArray();
            componentTriangles=Enumerable.Range(0,count).GroupBy(i=>components[i])
                .ToDictionary(group=>group.Key,group=>group.ToArray());
            ComponentCount=components.Distinct().Count();
        }
        public ArmyNavMeshConnection Classify(Vector3 start,Vector3 end)
        {
            if(!PlayerHitbox.Finite(start) || !PlayerHitbox.Finite(end))
                throw new ArgumentOutOfRangeException(nameof(start));
            int a=Locate(start),b=Locate(end);
            if(a<0 || b<0)return ArmyNavMeshConnection.Outside;
            return components[a]==components[b] ? ArmyNavMeshConnection.Connected :
                ArmyNavMeshConnection.Disconnected;
        }
        public Vector3? SampleNearest(Vector3 point,float radius)
        {
            if(!PlayerHitbox.Finite(point)||!float.IsFinite(radius)||radius<=0||radius>100)
                throw new ArgumentOutOfRangeException(nameof(point));
            Vector3 selected=default;float best=radius*radius;bool found=false;
            for(int triangle=0;triangle<indices.Count/3;triangle++)
            {
                var candidate=ClosestPoint(point,vertices[indices[triangle*3]],
                    vertices[indices[triangle*3+1]],vertices[indices[triangle*3+2]]);
                float squared=Vector3.DistanceSquared(point,candidate);
                if(squared<best || !found&&squared<=best)
                {best=squared;selected=candidate;found=true;}
            }
            return found?selected:null;
        }
        private static Vector3 ClosestPoint(Vector3 p,Vector3 a,Vector3 b,Vector3 c)
        {
            var ab=b-a;var ac=c-a;var ap=p-a;
            float d1=Vector3.Dot(ab,ap),d2=Vector3.Dot(ac,ap);
            if(d1<=0&&d2<=0)return a;
            var bp=p-b;float d3=Vector3.Dot(ab,bp),d4=Vector3.Dot(ac,bp);
            if(d3>=0&&d4<=d3)return b;
            float vc=d1*d4-d3*d2;
            if(vc<=0&&d1>=0&&d3<=0){float v=d1/(d1-d3);return a+v*ab;}
            var cp=p-c;float d5=Vector3.Dot(ab,cp),d6=Vector3.Dot(ac,cp);
            if(d6>=0&&d5<=d6)return c;
            float vb=d5*d2-d1*d6;
            if(vb<=0&&d2>=0&&d6<=0){float w=d2/(d2-d6);return a+w*ac;}
            float va=d3*d6-d5*d4;
            if(va<=0&&(d4-d3)>=0&&(d5-d6)>=0)
            {float w=(d4-d3)/((d4-d3)+(d5-d6));return b+w*(c-b);}
            float denominator=1/(va+vb+vc);float insideV=vb*denominator,insideW=vc*denominator;
            return a+ab*insideV+ac*insideW;
        }
        public ArmyNavMeshPolylineAudit InspectPolyline(IReadOnlyList<Vector3> points)
        {
            ArgumentNullException.ThrowIfNull(points);
            if(points.Count<2 || points.Count>1024 || points.Any(p=>!PlayerHitbox.Finite(p)))
                throw new InvalidDataException("Invalid navigation polyline audit input.");
            int first=Locate(points[0]),last=Locate(points[^1]);
            if(first<0 || last<0 || components[first]!=components[last])
                return new(false,float.PositiveInfinity);
            var triangles=componentTriangles[components[first]];
            bool covered=PlanarCovered(triangles,points);
            return new(covered,covered ? MeasureVerticalDeviation(triangles,points) :
                float.PositiveInfinity);
        }
        public ArmyNavMeshCorridor? PlanCorridor(Vector3 start,Vector3 end)
        {
            var ordinary=SolveCorridor(start,end,0);
            if(ordinary==null)return null;
            var direct=SolveCorridor(start,end,1);
            ArmyNavMeshCorridor selected;
            if(ordinary.PlanarCovered && direct?.PlanarCovered==true)
                selected=direct.SmoothedLength<ordinary.SmoothedLength ? direct : ordinary;
            else if(ordinary.PlanarCovered)selected=ordinary;
            else if(direct?.PlanarCovered==true)selected=direct;
            else throw new InvalidDataException("No planar-covered NavMesh corridor for connected endpoints.");
            selected=PruneAcrossComponent(selected,start);
            if(selected.SmoothedLength>Vector3.Distance(start,end)*1.08f)
            {
                var visible=SearchVisibleVertices(start,end,selected);
                if(visible!=null && visible.SmoothedLength<selected.SmoothedLength)
                    selected=visible;
            }
            return selected;
        }
        private ArmyNavMeshCorridor? SearchVisibleVertices(Vector3 start,Vector3 end,
            ArmyNavMeshCorridor original)
        {
            var triangles=componentTriangles[components[Locate(start)]];
            var axis=new Vector2(end.X-start.X,end.Z-start.Z);
            float squared=axis.LengthSquared();
            if(squared<=.001f)return null;
            var seen=new HashSet<VertexKey>();
            var nearby=new List<(Vector3 Point,float T,float Offset)>();
            foreach(var point in vertices)
            {
                if(!seen.Add(VertexKey.From(point)))continue;
                var offset=new Vector2(point.X-start.X,point.Z-start.Z);
                float t=Vector2.Dot(offset,axis)/squared;
                if(t<=.001f || t>=.999f)continue;
                float distance=Vector2.Distance(offset,axis*t);
                if(distance<=.75f)nearby.Add((point,t,distance));
            }
            var nodes=nearby.OrderBy(x=>x.Offset).ThenBy(x=>x.T).Take(48)
                .OrderBy(x=>x.T).Select(x=>x.Point).ToList();
            nodes.Insert(0,start);nodes.Add(end);
            var cost=Enumerable.Repeat(float.PositiveInfinity,nodes.Count).ToArray();
            var previous=Enumerable.Repeat(-1,nodes.Count).ToArray();
            cost[0]=0;
            for(int from=0;from<nodes.Count-1;from++)
            {
                if(!float.IsFinite(cost[from]))continue;
                for(int to=from+1;to<nodes.Count;to++)
                {
                    float next=cost[from]+Vector3.Distance(nodes[from],nodes[to]);
                    if(next>=cost[to] || next>=original.SmoothedLength)continue;
                    Vector3[] segment=[nodes[from],nodes[to]];
                    if(!PlanarCovered(triangles,segment) ||
                       MeasureVerticalDeviation(triangles,segment)>.25f)continue;
                    cost[to]=next;previous[to]=from;
                }
            }
            if(!float.IsFinite(cost[^1]) || cost[^1]>=original.SmoothedLength)return null;
            var path=new List<Vector3>();
            for(int at=nodes.Count-1;at>=0;at=previous[at])
            {
                path.Add(nodes[at]);
                if(at==0)break;
                if(previous[at]<0)throw new InvalidDataException("Broken visible NavMesh route.");
            }
            path.Reverse();
            float height=MeasureVerticalDeviation(triangles,path);
            if(!PlanarCovered(triangles,path) || height>.25f)
                throw new InvalidDataException("Visible NavMesh route failed revalidation.");
            var points=Array.AsReadOnly(path.ToArray());
            return original with {Points=points,Length=cost[^1],
                SmoothedPoints=points,SmoothedLength=cost[^1],
                PlanarCovered=true,MaxVerticalDeviation=height};
        }
        private ArmyNavMeshCorridor PruneAcrossComponent(ArmyNavMeshCorridor selected,Vector3 start)
        {
            var path=selected.SmoothedPoints;
            if(path.Count<=2)return selected;
            var triangles=componentTriangles[components[Locate(start)]];
            var reduced=new List<Vector3>{path[0]};
            for(int from=0;from<path.Count-1;)
            {
                int next=from+1;
                for(int candidate=path.Count-1;candidate>next;candidate--)
                {
                    Vector3[] segment=[path[from],path[candidate]];
                    if(PlanarCovered(triangles,segment) &&
                       MeasureVerticalDeviation(triangles,segment)<=.25f)
                    {next=candidate;break;}
                }
                reduced.Add(path[next]);from=next;
            }
            if(reduced.Count==path.Count)return selected;
            float length=0;
            for(int i=1;i<reduced.Count;i++)length+=Vector3.Distance(reduced[i-1],reduced[i]);
            return selected with {SmoothedPoints=Array.AsReadOnly(reduced.ToArray()),
                SmoothedLength=length,PlanarCovered=PlanarCovered(triangles,reduced),
                MaxVerticalDeviation=MeasureVerticalDeviation(triangles,reduced)};
        }
        private ArmyNavMeshCorridor? SolveCorridor(Vector3 start,Vector3 end,float lineBias)
        {
            if(!PlayerHitbox.Finite(start) || !PlayerHitbox.Finite(end))
                throw new ArgumentOutOfRangeException(nameof(start));
            int first=Locate(start),last=Locate(end);
            if(first<0 || last<0 || components[first]!=components[last])return null;
            int count=components.Length;
            var cost=Enumerable.Repeat(float.PositiveInfinity,count).ToArray();
            var previous=Enumerable.Repeat(-1,count).ToArray();
            var closed=new bool[count];
            var queue=new PriorityQueue<int,float>();
            cost[first]=0;queue.Enqueue(first,Vector3.Distance(centroids[first],centroids[last]));
            while(queue.TryDequeue(out int current,out _))
            {
                if(closed[current])continue;
                if(current==last)break;
                closed[current]=true;
                foreach(var neighbor in neighbors[current])
                {
                    int next=neighbor.Triangle;
                    if(closed[next])continue;
                    float step=Vector3.Distance(centroids[current],centroids[next]);
                    float candidate=cost[current]+step*(1+lineBias*DistanceToSegmentXZ(
                        centroids[next],start,end));
                    if(candidate>=cost[next])continue;
                    cost[next]=candidate;previous[next]=current;
                    queue.Enqueue(next,candidate+Vector3.Distance(centroids[next],centroids[last]));
                }
            }
            if(first!=last && previous[last]<0)
                throw new InvalidDataException("Connected NavMesh triangles have no corridor.");
            var corridor=new List<int>();
            for(int current=last;current>=0;current=previous[current])
            {
                corridor.Add(current);
                if(current==first)break;
                if(corridor.Count>count)throw new InvalidDataException("Cyclic navigation corridor.");
            }
            corridor.Reverse();
            var points=new List<Vector3>(corridor.Count+1){start};
            for(int i=1;i<corridor.Count;i++)
            {
                var portal=neighbors[corridor[i-1]].Single(n=>n.Triangle==corridor[i]).Portal;
                points.Add(portal);
            }
            points.Add(end);
            float length=0;
            for(int i=1;i<points.Count;i++)length+=Vector3.Distance(points[i-1],points[i]);
            if(!float.IsFinite(length) || length<0 || points.Count>count+1)
                throw new InvalidDataException("Invalid navigation corridor length.");
            var portals=new List<Portal>(corridor.Count+1){new(start,start)};
            for(int i=1;i<corridor.Count;i++)
            {
                int from=corridor[i-1],to=corridor[i];
                var edge=neighbors[from].Single(n=>n.Triangle==to);
                var middle=(edge.A+edge.B)/2f;
                var travel=centroids[to]-centroids[from];
                bool firstLeft=Cross(Vector3.Zero,travel,edge.A-middle)<=0;
                portals.Add(firstLeft?new(edge.A,edge.B):new(edge.B,edge.A));
            }
            portals.Add(new(end,end));
            var smooth=Funnel(portals);
            float smoothLength=0;
            for(int i=1;i<smooth.Count;i++)smoothLength+=Vector3.Distance(smooth[i-1],smooth[i]);
            if(!float.IsFinite(smoothLength) || smoothLength<0 || smooth.Count>points.Count)
                throw new InvalidDataException("Invalid smoothed navigation path.");
            return new(Array.AsReadOnly(points.ToArray()),length,
                Array.AsReadOnly(smooth.ToArray()),smoothLength,PlanarCovered(corridor,smooth),
                MeasureVerticalDeviation(corridor,smooth));
        }
        private float MeasureVerticalDeviation(IReadOnlyList<int> corridor,IReadOnlyList<Vector3> path)
        {
            float maximum=0;
            for(int segment=1;segment<path.Count;segment++)
            {
                var from=path[segment-1];var to=path[segment];
                int samples=Math.Max(1,(int)Math.Ceiling(Vector2.Distance(
                    new(from.X,from.Z),new(to.X,to.Z))/.25f));
                for(int sample=0;sample<=samples;sample++)
                {
                    var point=Vector3.Lerp(from,to,(float)sample/samples);
                    double best=double.PositiveInfinity;
                    foreach(int triangle in corridor)
                    {
                        var a=vertices[indices[triangle*3]];
                        var b=vertices[indices[triangle*3+1]];
                        var c=vertices[indices[triangle*3+2]];
                        double denominator=Cross(a,b,c);
                        if(Math.Abs(denominator)<1e-8)continue;
                        double u=Cross(point,b,c)/denominator;
                        double v=Cross(a,point,c)/denominator;
                        double w=1-u-v;
                        if(Math.Min(u,Math.Min(v,w))<-.0005)continue;
                        best=Math.Min(best,Math.Abs(point.Y-(u*a.Y+v*b.Y+w*c.Y)));
                    }
                    if(double.IsPositiveInfinity(best))return float.PositiveInfinity;
                    maximum=Math.Max(maximum,(float)best);
                }
            }
            return maximum;
        }
        private bool PlanarCovered(IReadOnlyList<int> corridor,IReadOnlyList<Vector3> path)
        {
            for(int segment=1;segment<path.Count;segment++)
            {
                var intervals=new List<(double Start,double End)>();
                foreach(int triangle in corridor)
                {
                    var a=vertices[indices[triangle*3]];
                    var b=vertices[indices[triangle*3+1]];
                    var c=vertices[indices[triangle*3+2]];
                    double denominator=Cross(a,b,c);
                    if(Math.Abs(denominator)<1e-8)continue;
                    static double[] Barycentric(Vector3 p,Vector3 a,Vector3 b,Vector3 c,double area)
                    {
                        double u=Cross(p,b,c)/area;
                        double v=Cross(a,p,c)/area;
                        return [u,v,1-u-v];
                    }
                    var atStart=Barycentric(path[segment-1],a,b,c,denominator);
                    var atEnd=Barycentric(path[segment],a,b,c,denominator);
                    double low=0,high=1;
                    for(int coordinate=0;coordinate<3 && low<=high;coordinate++)
                    {
                        double origin=atStart[coordinate]+.0005;
                        double slope=atEnd[coordinate]-atStart[coordinate];
                        if(Math.Abs(slope)<1e-12)
                        {if(origin<0)low=2;continue;}
                        double boundary=-origin/slope;
                        if(slope>0)low=Math.Max(low,boundary);
                        else high=Math.Min(high,boundary);
                    }
                    if(low<=high)intervals.Add((low,high));
                }
                intervals.Sort((x,y)=>x.Start.CompareTo(y.Start));
                double covered=0;
                foreach(var interval in intervals)
                {
                    if(interval.Start>covered+.0001)break;
                    covered=Math.Max(covered,interval.End);
                    if(covered>=1-.0001)break;
                }
                if(covered<1-.0001)return false;
            }
            return true;
        }
        private static double Cross(Vector3 a,Vector3 b,Vector3 c)
            =>((double)b.X-a.X)*(c.Z-a.Z)-((double)b.Z-a.Z)*(c.X-a.X);
        private static float DistanceToSegmentXZ(Vector3 point,Vector3 start,Vector3 end)
        {
            var direction=new Vector2(end.X-start.X,end.Z-start.Z);
            var offset=new Vector2(point.X-start.X,point.Z-start.Z);
            float lengthSquared=direction.LengthSquared();
            float fraction=lengthSquared>0 ? Math.Clamp(Vector2.Dot(offset,direction)/lengthSquared,0,1) : 0;
            return Vector2.Distance(offset,direction*fraction);
        }
        private static bool Same(Vector3 a,Vector3 b)=>Vector3.DistanceSquared(a,b)<1e-10f;
        private static List<Vector3> Funnel(IReadOnlyList<Portal> portals)
        {
            var result=new List<Vector3>{portals[0].Left};
            var apex=portals[0].Left;var left=apex;var right=apex;
            int apexIndex=0,leftIndex=0,rightIndex=0,steps=0;
            for(int i=1;i<portals.Count;i++)
            {
                if(++steps>portals.Count*portals.Count)
                    throw new InvalidDataException("NavMesh funnel did not converge.");
                var nextLeft=portals[i].Left;var nextRight=portals[i].Right;
                if(Cross(apex,right,nextRight)<=0)
                {
                    if(Same(apex,right) || Cross(apex,left,nextRight)>0)
                    {right=nextRight;rightIndex=i;}
                    else
                    {
                        if(!Same(result[^1],left))result.Add(left);
                        apex=left;apexIndex=leftIndex;left=apex;right=apex;
                        leftIndex=apexIndex;rightIndex=apexIndex;i=apexIndex;continue;
                    }
                }
                if(Cross(apex,left,nextLeft)>=0)
                {
                    if(Same(apex,left) || Cross(apex,right,nextLeft)<0)
                    {left=nextLeft;leftIndex=i;}
                    else
                    {
                        if(!Same(result[^1],right))result.Add(right);
                        apex=right;apexIndex=rightIndex;left=apex;right=apex;
                        leftIndex=apexIndex;rightIndex=apexIndex;i=apexIndex;
                    }
                }
            }
            if(!Same(result[^1],portals[^1].Left))result.Add(portals[^1].Left);
            return result;
        }
        private int Locate(Vector3 point)
        {
            int selected=-1;double bestHeight=double.PositiveInfinity;
            for(int triangle=0;triangle<indices.Count/3;triangle++)
            {
                var a=vertices[indices[triangle*3]];
                var b=vertices[indices[triangle*3+1]];
                var c=vertices[indices[triangle*3+2]];
                double denominator=(b.Z-c.Z)*(a.X-c.X)+(c.X-b.X)*(a.Z-c.Z);
                if(Math.Abs(denominator)<1e-8)continue;
                double u=((b.Z-c.Z)*(point.X-c.X)+(c.X-b.X)*(point.Z-c.Z))/denominator;
                double v=((c.Z-a.Z)*(point.X-c.X)+(a.X-c.X)*(point.Z-c.Z))/denominator;
                double w=1-u-v;
                if(Math.Min(u,Math.Min(v,w))<-.0005)continue;
                double height=Math.Abs(point.Y-(u*a.Y+v*b.Y+w*c.Y));
                if(height<bestHeight){bestHeight=height;selected=triangle;}
            }
            // Unity's SamplePosition probes within three source world units;
            // the exported triangulation can differ slightly in height.
            return bestHeight<=3.01 ? selected : -1;
        }
    }
}
