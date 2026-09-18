using System;
using System.Text;
using CodeStage.AdvancedFPSCounter.Labels;
using UnityEngine;

namespace CodeStage.AdvancedFPSCounter.CountersData;

[Serializable]
public class DeviceInfoCounterData : BaseCounterData
{
	[HideInInspector]
	public string lastValue = string.Empty;

	[SerializeField]
	private bool cpuModel = true;

	[SerializeField]
	private bool gpuModel = true;

	[SerializeField]
	private bool ramSize = true;

	[SerializeField]
	private bool screenData = true;

	private bool inited;

	public bool CpuModel
	{
		get
		{
			return cpuModel;
		}
		set
		{
			if (cpuModel != value && Application.isPlaying)
			{
				cpuModel = value;
				if (enabled)
				{
					Refresh();
				}
			}
		}
	}

	public bool GpuModel
	{
		get
		{
			return gpuModel;
		}
		set
		{
			if (gpuModel != value && Application.isPlaying)
			{
				gpuModel = value;
				if (enabled)
				{
					Refresh();
				}
			}
		}
	}

	public bool RamSize
	{
		get
		{
			return ramSize;
		}
		set
		{
			if (ramSize != value && Application.isPlaying)
			{
				ramSize = value;
				if (enabled)
				{
					Refresh();
				}
			}
		}
	}

	public bool ScreenData
	{
		get
		{
			return screenData;
		}
		set
		{
			if (screenData != value && Application.isPlaying)
			{
				screenData = value;
				if (enabled)
				{
					Refresh();
				}
			}
		}
	}

	internal DeviceInfoCounterData()
	{
		color = new Color32(172, 172, 172, byte.MaxValue);
		anchor = LabelAnchor.LowerLeft;
	}

	protected override void CacheCurrentColor()
	{
		colorCached = "<color=#" + AFPSCounter.Color32ToHex(color) + ">";
	}

	internal override void Activate()
	{
		if (enabled && !inited && HasData())
		{
			base.Activate();
			inited = true;
			if (main.OperationMode == AFPSCounterOperationMode.Normal && colorCached == null)
			{
				colorCached = "<color=#" + AFPSCounter.Color32ToHex(color) + ">";
			}
			if (text == null)
			{
				text = new StringBuilder();
			}
			else
			{
				text.Remove(0, text.Length);
			}
			UpdateValue();
		}
	}

	internal override void Deactivate()
	{
		if (inited)
		{
			base.Deactivate();
			if (text != null)
			{
				text.Length = 0;
			}
			main.MakeDrawableLabelDirty(anchor);
			inited = false;
		}
	}

	internal override void UpdateValue(bool force)
	{
		if (!inited && HasData())
		{
			Activate();
		}
		else if (inited && !HasData())
		{
			Deactivate();
		}
		else
		{
			if (!enabled)
			{
				return;
			}
			bool flag = false;
			text.Remove(0, text.Length);
			if (cpuModel)
			{
				text.Append("CPU: ").Append(SystemInfo.processorType).Append(" (")
					.Append(SystemInfo.processorCount)
					.Append(" threads)");
				flag = true;
			}
			if (gpuModel)
			{
				if (flag)
				{
					text.Append(AFPSCounter.NEW_LINE);
				}
				text.Append("GPU: ").Append(SystemInfo.graphicsDeviceName);
				bool flag2 = false;
				switch (SystemInfo.graphicsShaderLevel)
				{
				case 20:
					text.Append(" (SM: 2.0");
					flag2 = true;
					break;
				case 30:
					text.Append(" (SM: 3.0");
					flag2 = true;
					break;
				case 40:
					text.Append(" (SM: 4.0");
					flag2 = true;
					break;
				case 41:
					text.Append(" (SM: 4.1");
					flag2 = true;
					break;
				case 50:
					text.Append(" (SM: 5.0");
					flag2 = true;
					break;
				}
				int graphicsMemorySize = SystemInfo.graphicsMemorySize;
				if (graphicsMemorySize > 0)
				{
					if (flag2)
					{
						text.Append(", VRAM: ").Append(graphicsMemorySize).Append(" MB)");
					}
					else
					{
						text.Append("(VRAM: ").Append(graphicsMemorySize).Append(" MB)");
					}
				}
				else if (flag2)
				{
					text.Append(")");
				}
				flag = true;
			}
			if (ramSize)
			{
				if (flag)
				{
					text.Append(AFPSCounter.NEW_LINE);
				}
				int systemMemorySize = SystemInfo.systemMemorySize;
				if (systemMemorySize > 0)
				{
					text.Append("RAM: ").Append(systemMemorySize).Append(" MB");
					flag = true;
				}
			}
			if (screenData)
			{
				if (flag)
				{
					text.Append(AFPSCounter.NEW_LINE);
				}
				Resolution currentResolution = Screen.currentResolution;
				text.Append("Screen: ").Append(currentResolution.width).Append("x")
					.Append(currentResolution.height)
					.Append("@")
					.Append(currentResolution.refreshRate)
					.Append("Hz (window size: ")
					.Append(Screen.width)
					.Append("x")
					.Append(Screen.height);
				float dpi = Screen.dpi;
				if (dpi <= 0f)
				{
					text.Append(")");
				}
				else
				{
					text.Append(", DPI: ").Append(dpi).Append(")");
				}
			}
			lastValue = text.ToString();
			if (main.OperationMode == AFPSCounterOperationMode.Normal)
			{
				text.Insert(0, colorCached);
				text.Append("</color>");
			}
			else
			{
				text.Length = 0;
			}
			dirty = true;
		}
	}

	private bool HasData()
	{
		return cpuModel || gpuModel || ramSize || screenData;
	}
}
