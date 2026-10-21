"""Read an OS process creation identity without third-party packages or shell parsing."""

from __future__ import annotations

import ctypes
import os
import re
import sys
from pathlib import Path


IDENTITY = re.compile(r"(?:windows:[1-9][0-9]{0,19}|linux:[0-9a-f]{8}(?:-[0-9a-f]{4}){3}"
                      r"-[0-9a-f]{12}:(?:0|[1-9][0-9]{0,19}))\Z")


def valid_identity(value: object) -> bool:
    return (isinstance(value, str) and IDENTITY.fullmatch(value) is not None
            and int(value.rsplit(":", 1)[1]) <= 0xFFFFFFFFFFFFFFFF)


def process_start_identity(pid: int) -> str | None:
    """Return an exact creation token; inaccessible, exited or unsupported processes return None."""
    if type(pid) is not int or not 0 < pid <= 0xFFFFFFFF:
        return None
    try:
        if os.name == "nt":
            return windows_identity(pid)
        if sys.platform == "linux":
            return linux_identity(pid)
    except (OSError, ValueError, IndexError):
        return None
    return None


def windows_identity(pid: int) -> str | None:
    kernel = ctypes.WinDLL("kernel32", use_last_error=True)
    kernel.OpenProcess.restype = ctypes.c_void_p
    kernel.OpenProcess.argtypes = [ctypes.c_ulong, ctypes.c_int, ctypes.c_ulong]
    kernel.GetProcessTimes.argtypes = [ctypes.c_void_p] + [ctypes.POINTER(ctypes.c_ulonglong)] * 4
    kernel.GetExitCodeProcess.argtypes = [ctypes.c_void_p, ctypes.POINTER(ctypes.c_ulong)]
    kernel.CloseHandle.argtypes = [ctypes.c_void_p]
    handle = kernel.OpenProcess(0x1000, False, pid)
    if not handle:
        return None
    try:
        created, exited, kernel_time, user_time = (ctypes.c_ulonglong() for _ in range(4))
        if not kernel.GetProcessTimes(handle, ctypes.byref(created), ctypes.byref(exited),
                                      ctypes.byref(kernel_time), ctypes.byref(user_time)):
            return None
        code = ctypes.c_ulong()
        if not kernel.GetExitCodeProcess(handle, ctypes.byref(code)) or code.value != 259:
            return None
        return f"windows:{created.value}" if created.value else None
    finally:
        kernel.CloseHandle(handle)


def linux_identity(pid: int) -> str | None:
    # comm may contain spaces and parentheses; fields after its final ')' start at field 3.
    fields = Path(f"/proc/{pid}/stat").read_text(encoding="utf-8").rsplit(")", 1)[1].split()
    if fields[0] in ("Z", "X", "x"):
        return None
    ticks = fields[19]
    boot_id = Path("/proc/sys/kernel/random/boot_id").read_text(encoding="ascii").strip()
    identity = f"linux:{boot_id}:{ticks}"
    return identity if valid_identity(identity) else None
