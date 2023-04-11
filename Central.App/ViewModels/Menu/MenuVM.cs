using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class MenuVM : PanelVM<Menu>, IMenu
    {
        #region Properties
        public override Menu Entity 
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;
                this.MenuEnum = entity.MenuEnum;
                this.Text = entity.Text;
                this.Icon = entity.Icon;
            }
            get => base.Entity; 
        }

        public MenuEnum MenuEnum { get; set; } = MenuEnum.Save;

        private string Text_ = "Save";
        public string Text
        {
            set {
                Text_ = value;
                this.Title1 = Text_;
                this.OnPropertyChanged();
            }
            get { return Text_; }
        }

        private string Icon_ = IconFont.Save;
        public string Icon
        {
            set { this.OnSetProperty(ref Icon_, value); }
            get { return Icon_; }
        }

        public bool IsViewIcon
        {
            get { return this.Icon.Trim() == "" ? false : true; }
        }
        public bool IsViewSpace
        {
            get {
                return this.IsViewTitle1 && this.IsViewIcon;
            }
        }
        #endregion Properties

        public MenuVM(Menu entity) : base(entity) { }
        public override void OnSelect()
        {
            base.OnSelect();
            this.OnMenuSelect(this.MenuEnum);
        }
    }
}
