"""Compatibility entry point for the scoped Desert rendering repair/check."""
import sys
from repair_gameplay_rendering import main

if __name__ == '__main__':
    if '--scene' not in sys.argv:
        sys.argv.extend(['--scene', 'Desert_Multiplayer'])
    main()
