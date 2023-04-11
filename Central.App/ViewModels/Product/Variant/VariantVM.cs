using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.ViewModels
{
    public class VariantVM : PanelVM<Variant>
    {
        #region Properties
        public override Variant Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Nama = entity.Nama;
                this.Deskripsi = Base.ToString(entity.VariantItems, ',');
                this.VariantItems = entity.VariantItems;
            }
            get {
                var entity = base.Entity;
                entity.Nama = this.Nama;
                entity.VariantItems = this.VariantItems;
                return entity;
            } 
        }
        public InputTextVM InputVM { get; set; }
        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }

        private string Nama_;
        public string Nama
        {
            set {
                Nama_ = Base.ToString(value).Trim();
                this.IsNew = Nama_ == "" ? true : false;

                try { this.InputVM.TextHint1 = Nama_; } catch { }
                try { this.InputNamaVM.Text = Nama_; } catch { }
                this.OnPropertyChanged();
            }
            get {
                try { return this.InputNamaVM.Text.Trim(); }
                catch { return Nama_; }
            }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set { this.OnSetProperty(ref Deskripsi_, value); }
            get { return Deskripsi_; }
        }

        private List<string> VariantItems_;
        public List<string> VariantItems
        {
            set {
                if (value is null) return;

                VariantItems_ = value;
                var text = Base.ToString(VariantItems_, ',');
                try { this.InputVM.Text = text; } catch { }
                try { this.InputDeskripsiVM.Text = text; } catch { }
            }
            get {
                try { return Base.ToList(this.InputVM.Text.Trim(), ','); } catch { }
                try { return Base.ToList(this.InputDeskripsiVM.Text.Trim(), ','); } catch { }                    
                return VariantItems_;
            }
        }

        public override bool IsNew { 
            set {
                var isnew = value;
                base.IsNew = isnew;
                this.Title2 = isnew ? "Tambah Variant" : $"Edit Variant - {this.Nama}";
                try { this.InputNamaVM.IsReadOnly = !isnew; } catch { }
            }
            get => base.IsNew;
        }

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        #region Event
        public delegate void VariantEventHandler(VariantVM vm);
        public event VariantEventHandler VariantEdit, VariantDelete;
        #endregion Event

        public VariantVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public VariantVM(Variant entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
        
        protected override void OnInitInput(Variant entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Info) {
                //------untuk tampilan yg di edit product----//
                this.InputVM = new InputTextVM(new InputText("Satuan", "*Input dengan pemisah koma (,)", "") { IsTitleCase = true });
                this.InputVM.IsReadOnly = true;
            }
            else if (panelenum == PanelEnum.Edit1) {
                //------untuk tampilan yg di edit variant----//
                this.InputNamaVM = new InputTextVM(new InputText("Nama Varian", "", "Cth : Satuan, Warna, Ukuran, dll...") { IsTitleCase = true });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi Varian", "", "*Input dengan pemisah koma (,)") { IsTitleCase = true });
            }
        }
        protected override void OnInitEvent(Variant entity, PanelEnum panelenum)
        {
            base.OnInitEvent(entity, panelenum);
            if (panelenum == PanelEnum.Info) {
                this.InputVM.Select += ((vm) => this.OnMenuSelect(MenuEnum.Edit));
                this.InputVM.MenuSelectedChanged += this.OnMenuSelect;
            }
        }

        public override async void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.Edit: {
                        if (this.VariantEdit != null) this.VariantEdit(this);
                        break;
                    }
                case MenuEnum.Delete: {
                        var isok = await this.OnAlert("Hapus", "Anda yakin ingin hapus varian ini ?", "OK", "Cancel");
                        if (isok) {
                            if (this.VariantDelete != null) this.VariantDelete(this);
                        }
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

    }
}
