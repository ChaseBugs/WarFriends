"""Refresh source indexes in the root Server_guide.md; does not alter Client files.

These are lexical discovery indexes, not a C# semantic parser. Field candidates
and reader keys require branch-by-branch review before implementing a contract.
"""
from pathlib import Path
import hashlib
import re

ROOT = Path(__file__).resolve().parents[2]
GAME = ROOT / 'Clients/ExportedProject/Assets/Scripts/Assembly-CSharp'
SHEETS = ROOT / 'Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u'
GUIDE = ROOT / 'Server_guide.md'
MARKER = '<!-- GENERATED_SOURCE_APPENDICES -->'
sources = {p: p.read_text(encoding='utf-8-sig') for p in sorted(GAME.glob('*.cs'))}
out = []


def emit(s=''):
    out.append(s)


def link(p, line=1, label=None):
    rel = p.relative_to(ROOT).as_posix()
    return f'[{label or p.stem}]({rel}#L{line})'


def cell(s):
    return s.replace('|', '&#124;').replace('\n', ' ')


def methods(t):
    pattern = r'^\t(?:(?:public|private|protected|internal|static|override|virtual|sealed|async)\s+)+[\w<>,.?\[\]]+\s+(\w+)\([^\n]*\)'
    matches = list(re.finditer(pattern, t, re.M))
    return [(m[1], t.count('\n', 0, m.start()) + 1,
             t[m.start():matches[i+1].start() if i+1 < len(matches) else len(t)])
            for i, m in enumerate(matches)]


actions = {n: int(v) for n, v in re.findall(r'^\s*(\w+)\s*=\s*(\d+)', sources[GAME/'DatabaseAction.cs'], re.M)}
builders = []
for name, line, body in methods(sources[GAME/'BeanstalkServerManager.cs']):
    sent = sorted(set(re.findall(r'CreateServerRequest\(DatabaseAction\.(\w+)', body)))
    if sent:
        fields = sorted(set(re.findall(r'new Tuple<string, string>\("([^"]+)"', body)))
        builders.append((name, line, sent, fields))

emit('## Appendix A. Complete named action inventory')
emit()
emit('Generated from the active enum, not a copied later-version list. A missing direct builder means **inspect references**, not "unsupported" or "safe to implement empty". Callback/result and diagnostic identifiers are retained. Complete direct builder fields follow in Appendix B.')
emit()
emit('| ID | Exact Client name | Direct builder(s) | Other source reference example |')
emit('|---:|---|---|---|')
for name, value in sorted(actions.items(), key=lambda x: x[1]):
    bs = ', '.join(link(GAME/'BeanstalkServerManager.cs', line, method) for method, line, sent, _ in builders if name in sent)
    refs = []
    for p, t in sources.items():
        if p.name in {'DatabaseAction.cs', 'BeanstalkServerManager.cs'}:
            continue
        m = re.search(r'\bDatabaseAction\.' + name + r'\b', t)
        if m:
            refs.append(link(p, t.count('\n', 0, m.start()) + 1))
    emit(f'| {value} | `{name}` | {bs or "Inspect caller / buffer / dispatch"} | {", ".join(refs[:2]) or "No direct enum reference found"} |')

emit('\n## Appendix B. Direct request DTO field candidates\n')
emit('Fields are literal tuple names grouped by builder method. Conditional fields, dynamic keys, common auth fields and nested JSON need source review; a listed field is **not necessarily required**. No fields found means no literal tuple fields in this method, not necessarily an empty wire request. Overloads may repeat.\n')
emit('| Builder | Action ID/name | Literal action field candidates |')
emit('|---|---|---|')
for method, line, sent, fields in builders:
    names = ', '.join(f'{actions.get(n, "?")} `{n}`' for n in sent)
    emit(f'| {link(GAME/"BeanstalkServerManager.cs", line, method)} | {names} | {", ".join("`"+f+"`" for f in fields) or "None found"} |')

emit('\n### Requests sent outside BeanstalkServerManager\n')
emit('These callers use the public SendServerRequest wrapper, including Arena, Instant Battle and dynamic purchase actions. Dynamic action expressions require caller inspection.\n')
emit('| Source / method | Named action or dynamic expression | Literal tuple fields |')
emit('|---|---|---|')
for p,t in sources.items():
    if p.name == 'BeanstalkServerManager.cs':
        continue
    for method,line,body in methods(t):
        if 'SendServerRequest(' not in body:
            continue
        sent=sorted(set(re.findall(r'SendServerRequest\(DatabaseAction\.(\w+)',body)))
        fields=sorted(set(re.findall(r'new Tuple<string, string>\("([^"]+)"',body)))
        emit(f'| {link(p,line,method)} | {", ".join(sent) or "Dynamic; inspect source"} | {", ".join("`"+f+"`" for f in fields) or "None found"} |')

emit('\n## Appendix C. Response reader DTO keys\n')
emit('Literal `mResponse[...]` keys grouped by method. This list intentionally does not label all keys mandatory: inspect `ContainsKey`, null checks and result-code branches. Nested `StringParser`/DTO readers add fields beyond this envelope index.\n')
emit('| Reader | Direct envelope keys |')
emit('|---|---|')
for method, line, body in methods(sources[GAME/'ServerResponseHandler.cs']):
    keys = sorted(set(re.findall(r'mResponse\["([^"]+)"\]', body)))
    if keys:
        emit(f'| {link(GAME/"ServerResponseHandler.cs", line, method)} | {", ".join("`"+k+"`" for k in keys)} |')

emit('\n### Delegated response readers\n')
emit('Literal response dictionary keys in separate OnSuccess/OnError readers; these are also conditional candidates, not an unconditional required-fields list.\n')
emit('| Source / method | Dictionary keys |')
emit('|---|---|')
for p,t in sources.items():
    for method,line,body in methods(t):
        if method not in {'OnSuccess','OnError'}:
            continue
        keys=sorted(set(re.findall(r'\bresponse\["([^"]+)"\]',body)))
        if keys:
            emit(f'| {link(p,line,method)} | {", ".join(keys)} |')

emit('\n## Appendix D. Persisted subsystem and supporting DTO declarations\n')
emit('Source C# field declarations retain their names/types/default expressions. These are **not protobuf definitions**. Computed properties, serialization attributes, custom converters, constructors and loader defaults must also be inspected at the linked source. Nested helper types are included; runtime manager fields are excluded. Obscured scalar wrappers need plain validated wire values.\n')
emit('| Manager | Serialized blob type |')
emit('|---|---|')
managers = []
for p, t in sources.items():
    m = re.search(r': DatabaseSerializedObjectGeneric<([^>]+)>', t)
    if m:
        managers.append(p)
        emit(f'| {link(p)} | `{m[1]}` |')

extras = ['DatabasePlayer', 'DatabasePlayerData', 'DatabaseSquad', 'DatabaseGameReward',
          'DatabaseSquadEventDefinition', 'DatabaseSquadEventProgress', 'WarArenaConfig',
          'DailyRewards', 'UpgradeSlots', 'PlayerProperties', 'DatabaseMessage',
          'WarDailyRewardsManager', 'DailyRewardMonthScreen', 'InstantBattleManager',
          'MissionDefinition', 'Request', 'AchievementsManager']
selected = sorted(set(managers + [GAME/(n+'.cs') for n in extras if GAME/(n+'.cs') in sources]))
for p in selected:
    t = sources[p]
    classes = list(re.finditer(r'^(\t*)(?:public|private|internal|protected)\s+(?:(?:sealed|abstract|static)\s+)?(?:class|struct)\s+(\w+)[^\n]*\n\s*\{', t, re.M))
    for m in classes:
        indent, name = m[1], m[2]
        if (p in managers or p.stem in {'DailyRewardMonthScreen', 'InstantBattleManager', 'AchievementsManager', 'UpgradeSlots'}) and not indent:
            continue
        end = re.search(r'^'+re.escape(indent)+r'\}', t[m.end():], re.M)
        body = t[m.end():m.end()+end.start()] if end else t[m.end():]
        fields = []
        for line in body.splitlines():
            if not line.startswith(indent+'\tpublic '):
                continue
            declaration = line[len(indent)+1:].strip()
            if '=>' in declaration or ' event ' in declaration or not declaration.endswith(';'):
                continue
            # Methods and property bodies are excluded; field initializers may call constructors.
            before = declaration.split('=', 1)[0]
            if '(' in before or '{' in before or ' static ' in declaration or ' const ' in declaration:
                continue
            fields.append(declaration)
        if fields:
            emit(f'\n### {p.stem}.{name}\n')
            emit(link(p, t.count('\n', 0, m.start())+1, 'Source declaration')+'\n')
            emit('```csharp\n'+'\n'.join(fields)+'\n```')

emit('\n## Appendix E. Complete discovered RPC definition checklist\n')
emit('Every row needs direction/authority classification, replacement DTO, delivery semantics and a parity test before Photon removal. Signatures containing Unity/Photon objects must be translated to IDs/scalars, not copied into the portable SDK. An RPC named damage/kill is not authorization for a Client to cause it.\n')
emit('| Source | Recovered RPC signature |')
emit('|---|---|')
rpc_count = 0
for p, t in sources.items():
    for m in re.finditer(r'\[(?:PunRPC|RPC)\]\s*((?:(?:public|private|protected|internal|virtual|override|static|sealed)\s+)*[\w<>\[\],]+\s+(\w+)\s*\([^)]*\))', t):
        rpc_count += 1
        emit(f'| {link(p, t.count(chr(10), 0, m.start())+1)} | `{cell(m[1])}` |')

emit('\n## Appendix F. Photon stream and buffered-call discovery\n')
emit('Streams are positional contracts: open each method and record write/read order, conditional branches and owner direction. These locations include calls as well as definitions. The existing JSON inventory separately records literal RPC call sites and PhotonView asset attachments.\n')
emit('| Source | OnPhotonSerializeView line(s) |')
emit('|---|---|')
stream_count = 0
for p,t in sources.items():
    ms = list(re.finditer(r'\bOnPhotonSerializeView\s*\(', t))
    if ms:
        stream_count += len(ms)
        emit(f'| {p.stem} | '+', '.join(link(p,t.count('\n',0,m.start())+1,str(t.count('\n',0,m.start())+1)) for m in ms)+' |')
emit('\n### Buffered request producers\n')
emit('Action-specific `data` schemas are assembled at these call sites. Read dictionary/object construction before the call; direct HTTP field candidates in Appendix B do not describe this inner JSON.\n')
emit('| Source | Buffered action references |')
emit('|---|---|')
for p,t in sources.items():
    matches = list(re.finditer(r'\bAddRequest\(\s*DatabaseAction\.(\w+)', t))
    if matches:
        emit(f'| {link(p)} | '+', '.join(link(p,t.count('\n',0,m.start())+1,f'{actions.get(m[1], "?")} {m[1]}') for m in matches)+' |')

emit('\n## Appendix G. Catalog schema inventory\n')
emit('These are schema class names, not proof of populated/validated table rows. Recover serialized values and the consuming gameplay mappings as described in section 5.\n')
rows = sorted(SHEETS.glob('*Row.cs'))
for start in range(0,len(rows),6):
    emit('- '+', '.join(link(p) for p in rows[start:start+6]))

emit('\n## Appendix H. Evidence digests and refresh\n')
emit('Refresh only these appendices with `python Server/tools/build_server_guide_appendices.py`. The authored guide must be reviewed separately when behavior changes. This lexical inventory scans top-level recovered gameplay scripts and Google2u schemas; third-party nested folders are not gameplay specifications.\n')
emit('| Source | SHA-256 |')
emit('|---|---|')
for name in ['DatabaseAction','BeanstalkServerManager','ServerResponseHandler','RequestBuffer','GameController','PhotonConnectionManager','CustomTypes']:
    p=GAME/(name+'.cs')
    emit(f'| {link(p)} | `{hashlib.sha256(p.read_bytes()).hexdigest()}` |')
emit(f'\nInventory totals: **{len(actions)} named actions; {len(builders)} direct builder entries; {len(managers)} serialized subsystem managers; {rpc_count} RPC definitions; {stream_count} serialization occurrences; {len(rows)} Google2u row schemas**. Counts measure source discovery, not implementation completeness.')
base = GUIDE.read_text(encoding='utf-8').split(MARKER)[0]
GUIDE.write_text(base+MARKER+'\n\n'+'\n'.join(out)+'\n',encoding='utf-8')
print(f'Updated {GUIDE.name}: {len(actions)} actions, {len(managers)} managers, {rpc_count} RPCs, {len(rows)} row schemas')
