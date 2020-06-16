using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HelpClasses
{
    public class AppListView : ListView
    {

        public AppListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            this.ItemSelected += (s, e) =>
            {
                this.TapCommand?.Execute(e.SelectedItem);
            };
        }

        #region Property TapCommand

        /// <summary>
        /// Bindable Property TapCommand
        /// </summary>
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
          nameof(TapCommand),
          typeof(System.Windows.Input.ICommand),
          typeof(AppListView),
          null,
          BindingMode.OneWay,
          null,
          null,
          null,
          null,
          null
        );

        /// <summary>
        /// Property TapCommand
        /// </summary>
        public System.Windows.Input.ICommand TapCommand
        {
            get
            {
                return (System.Windows.Input.ICommand)GetValue(TapCommandProperty);
            }
            set
            {
                SetValue(TapCommandProperty, value);
            }
        }
        #endregion

    }
}
