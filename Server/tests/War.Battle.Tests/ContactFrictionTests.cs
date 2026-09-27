using War.BattleServer;

internal static class ContactFrictionTests
{
    internal static int Run()
    {
        int count=0;
        void Check(bool value){if(!value)throw new Exception("Friction constraint boundary failed.");count++;}
        Check(ContactFrictionConstraint.Solve(0,-6,0,0,1,10,.6f,.4f)==new ContactFrictionStep(6,6,false));
        Check(ContactFrictionConstraint.Solve(0,-7,0,0,1,10,.6f,.4f)==new ContactFrictionStep(4,4,true));
        Check(ContactFrictionConstraint.Solve(0,7,0,0,1,10,.6f,.4f)==new ContactFrictionStep(-4,-4,true));
        Check(ContactFrictionConstraint.Solve(3,0,0,0,1,0,.6f,.4f)==new ContactFrictionStep(0,-3,true));
        Check(ContactFrictionConstraint.Solve(2,4,1,3,.5f,10,.6f,.4f)==new ContactFrictionStep(-1,-3,false));
        foreach(float invalid in new[]{float.NaN,float.PositiveInfinity,-1f})
        {
            try{ContactFrictionConstraint.Solve(0,0,0,0,1,invalid,.6f,.4f);
                throw new Exception("Invalid normal impulse accepted.");}
            catch(InvalidDataException){count++;}
        }
        return count;
    }
}
