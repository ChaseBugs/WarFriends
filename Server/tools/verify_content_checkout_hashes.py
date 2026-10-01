"""Verify Git checkout bytes satisfy every local content-manifest SHA-256 reference."""
import hashlib
import json
import os
import re
import shutil
import subprocess
import tempfile
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]


def git(*args):
    return subprocess.check_output(['git', *args], cwd=ROOT, text=True).splitlines()


def referenced_hashes(value):
    if isinstance(value, dict):
        for item in value.values():
            yield from referenced_hashes(item)
    elif isinstance(value, list):
        for item in value:
            yield from referenced_hashes(item)
    elif isinstance(value, str) and re.fullmatch(r'[0-9a-f]{64}', value):
        yield value


def main():
    files = git('ls-files', 'Server/content')
    content = {hashlib.sha256((ROOT / path).read_bytes()).hexdigest(): path
               for path in files if (ROOT / path).is_file()}
    referenced = {}
    for path in files:
        if not path.endswith('manifest.json'):
            continue
        for digest in referenced_hashes(json.loads((ROOT / path).read_text())):
            if digest in content:
                referenced[content[digest]] = digest
    if len(referenced) < 51:
        raise ValueError('Content manifest reference coverage fell below 51 artifacts')
    temporary = Path(tempfile.mkdtemp(prefix='war-content-checkout-')).resolve()
    try:
        for path, expected in sorted(referenced.items()):
            subprocess.run(['git', '-c', 'core.autocrlf=false', 'checkout-index', '-f',
                            '--prefix=' + str(temporary) + os.sep, '--', path],
                           cwd=ROOT, check=True, stdout=subprocess.DEVNULL)
            actual = hashlib.sha256((temporary / path).read_bytes()).hexdigest()
            if actual != expected:
                raise ValueError(f'Linux checkout changes pinned content: {path}')
        print(f'PASS: {len(referenced)} manifest-referenced content artifacts keep their SHA-256 on Linux checkout')
    finally:
        temp_root = Path(tempfile.gettempdir()).resolve()
        if temporary.name.startswith('war-content-checkout-') and temporary.is_relative_to(temp_root):
            shutil.rmtree(temporary)
        else:
            raise RuntimeError('Unsafe checkout-verifier cleanup path')


if __name__ == '__main__':
    main()
