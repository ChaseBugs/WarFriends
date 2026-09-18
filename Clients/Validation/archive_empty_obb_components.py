"""Archive source-empty missing components, retaining every GameObject."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT/'Clients/ExportedProject/Assets'
SOURCE = Path('E:/Temp/WarFriends-obb-recovery/corrected-export/ExportedProject/Assets')
rows = json.loads((ROOT/'Clients/Validation/asset-reference-audit.json').read_text())['missingScripts']
changes = {}
archive = []
for row in rows:
    path = ASSETS/row['path']
    text = changes.get(path, path.read_text(encoding='utf-8'))
    source = (SOURCE/row['path']).read_text(encoding='utf-8')
    pid = row['fileID']
    pattern = rf'--- !u!114 &{pid}\n.*?(?=--- !u!|\Z)'
    old = re.search(pattern,text,re.S)[0]
    recovered = re.search(pattern,source,re.S)[0]
    assert row['empty'] and 'm_Script: {fileID: 0}' in recovered
    assert recovered.split('  m_EditorClassIdentifier:')[-1].strip() == ''
    assert text.count('fileID: '+pid+'}') == 1, 'Referenced component must not be removed'
    attachment = '  - 114: {fileID: '+pid+'}\n'
    assert attachment in text
    go = re.search(r'm_GameObject: \{fileID: (\d+)\}',old)[1]
    go_block = re.search(rf'--- !u!1 &{go}\n.*?(?=--- !u!|\Z)',text,re.S)[0]
    name = re.search(r'  m_Name: ([^\n]*)',go_block)[1]
    archive.append(dict(path=row['path'],fileID=pid,gameObject=go,name=name,record=old))
    changes[path] = text.replace(old,'').replace(attachment,'')
if archive:
    destination = ROOT/'Clients/QuarantinedRecoveredSources/obb-empty-components.json'
    assert not destination.exists(), 'Do not overwrite original archive'
    destination.write_text(json.dumps(archive,indent=2),encoding='utf-8')
    for path,text in changes.items():path.write_text(text,encoding='utf-8',newline='\n')
print('Archived',len(archive),'source-empty components in',len(changes),'scenes')
