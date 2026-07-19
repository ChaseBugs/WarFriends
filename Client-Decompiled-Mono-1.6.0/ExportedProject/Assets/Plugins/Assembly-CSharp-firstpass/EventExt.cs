using System;
using System.Linq;

public static class EventExt
{
	public static void Call(this Action handler)
	{
		if (handler != null)
		{
			handler();
		}
	}

	public static void Call<T>(this Action<T> handler, T t)
	{
		if (handler != null)
		{
			handler(t);
		}
	}

	public static void Call<T, U>(this Action<T, U> handler, T t, U u)
	{
		if (handler != null)
		{
			handler(t, u);
		}
	}

	public static void Call<T, U, V>(this Action<T, U, V> handler, T t, U u, V v)
	{
		if (handler != null)
		{
			handler(t, u, v);
		}
	}

	public static void Call<T, U, V, W>(this Action<T, U, V, W> handler, T t, U u, V v, W w)
	{
		if (handler != null)
		{
			handler(t, u, v, w);
		}
	}

	public static R[] Call<R>(this Func<R> handler)
	{
		if (handler == null)
		{
			return new R[0];
		}
		return (from Func<R> f in handler.GetInvocationList()
			select f()).ToArray();
	}

	public static R[] Call<R, T>(this Func<T, R> handler, T t)
	{
		if (handler == null)
		{
			return new R[0];
		}
		return (from Func<T, R> f in handler.GetInvocationList()
			select f(t)).ToArray();
	}

	public static R[] Call<R, T, U>(this Func<T, U, R> handler, T t, U u)
	{
		if (handler == null)
		{
			return new R[0];
		}
		return (from Func<T, U, R> f in handler.GetInvocationList()
			select f(t, u)).ToArray();
	}

	public static R[] Call<R, T, U, V>(this Func<T, U, V, R> handler, T t, U u, V v)
	{
		if (handler == null)
		{
			return new R[0];
		}
		return (from Func<T, U, V, R> f in handler.GetInvocationList()
			select f(t, u, v)).ToArray();
	}

	public static R[] Call<R, T, U, V, W>(this Func<T, U, V, W, R> handler, T t, U u, V v, W w)
	{
		if (handler == null)
		{
			return new R[0];
		}
		return (from Func<T, U, V, W, R> f in handler.GetInvocationList()
			select f(t, u, v, w)).ToArray();
	}

	public static void Delay(this Action handler)
	{
		EventUtils.Delay(delegate
		{
			handler.Call();
		});
	}

	public static void Delay<T>(this Action<T> handler, T t)
	{
		EventUtils.Delay(delegate
		{
			handler.Call(t);
		});
	}

	public static void Delay<T, U>(this Action<T, U> handler, T t, U u)
	{
		EventUtils.Delay(delegate
		{
			handler.Call(t, u);
		});
	}

	public static void Delay<T, U, V>(this Action<T, U, V> handler, T t, U u, V v)
	{
		EventUtils.Delay(delegate
		{
			handler.Call(t, u, v);
		});
	}

	public static void Delay<T, U, V, W>(this Action<T, U, V, W> handler, T t, U u, V v, W w)
	{
		EventUtils.Delay(delegate
		{
			handler.Call(t, u, v, w);
		});
	}
}
