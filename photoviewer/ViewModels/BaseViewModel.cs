using System;
using MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace photoviewer.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
    }

    public abstract class ViewModelBase<TInit> : BaseViewModel
    {
        /// <summary>
        /// Инициализация модели
        /// </summary>
        /// <param name="parameter"></param>
        public void Init(string parameter)
        {
            var deserialized = JsonConvert.DeserializeObject<TInit>(parameter);
            RealInit(deserialized);
        }

        /// <summary>
        /// Инициализация модели
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void RealInit(TInit parameter);
    }
}
