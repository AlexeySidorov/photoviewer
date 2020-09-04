using System;
using MvvmCross.ViewModels;

namespace photoviewer.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
    }

    public class BaseViewModel<TInit> : MvxViewModel<TInit>
    {
        public override void Prepare(TInit parameter)
        {
            
        }
    }
}
