"""Archive broken, empty scene records; retain all GameObjects and source assets."""
import re
from pathlib import Path

root = Path(__file__).resolve().parents[2]
assets = root / 'Clients/ExportedProject/Assets'
scene = assets / 'Scenes/MainScene.unity'
text = scene.read_text()
archive = []
for identifier in (39341, 50038):
    match = re.search(rf'--- !u!114 &{identifier}\n.*?(?=--- !u!|\Z)', text, re.S)
    if match is None:
        continue
    assert 'm_Script: {fileID: 0}' in match[0]
    assert text.count(f'fileID: {identifier}}}') == 1
    archive.append(match[0])
    text = text.replace(match[0], '').replace(f'  - 114: {{fileID: {identifier}}}\n', '')
if archive:
    destination = root / 'Clients/QuarantinedRecoveredSources/MainScene-empty-components.yaml'
    assert not destination.exists()
    destination.write_text(''.join(archive))
    scene.write_text(text)
for name in ('MainScene', 'SplashScene'):
    lighting = (assets / f'Scenes/{name}/LightingData.asset').read_text()
    for field in ('m_Lightmaps', 'm_LightmappedRendererData', 'm_BakedReflectionProbeCubemaps'):
        assert f'{field}: []' in lighting
    assert 'm_LightProbes: {fileID: 0}' in lighting
    path = assets / f'Scenes/{name}.unity'
    text = re.sub(r'  m_LightmapSnapshot: \{[^\n]+\}', '  m_LightmapSnapshot: {fileID: 0}', path.read_text())
    path.write_text(text)
print('Empty component attachments archived; empty incompatible lighting snapshots detached.')
