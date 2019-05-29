
using UniRx;
using UnityEngine;
using System;

public class RadioButton : MonoBehaviour, IObservable<bool>
{
	private Subject<bool> _isHit = new Subject<bool>();

	public void Execute(bool isHit)
	{
		_isHit.OnNext(isHit);
	}

	public IDisposable Subscribe(IObserver<bool> observer)
	{
		return _isHit.Subscribe(observer);
	}

}


