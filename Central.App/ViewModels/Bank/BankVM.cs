﻿

using MongoDB.Driver.Core.Operations;

namespace Central.App.ViewModels
{
    public class BankVM : PanelVM<Bank>
    {
        #region Properties
        public override Bank Entity
        {
            set{
                if (value is null) return;
                var entity = value;
                base.Entity = entity;

                this.Nama = entity.Nama;
                this.Deskripsi = entity.Deskripsi;
                
                this.OnGetSaldo();
            }
            get {
                var entity = base.Entity;
                entity.Nama = this.Nama;
                entity.Deskripsi = this.Deskripsi;
                return entity;
            }
        }

        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }

        private string Nama_;
        public virtual string Nama
        {
            set {
                Nama_ = value;
                try { this.InputNamaVM.Text = Nama_; } catch { }
            }
            get { try { return this.InputNamaVM.Text; } catch { return Nama_; } }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set {
                Deskripsi_ = value;
                try { this.InputDeskripsiVM.Text = Deskripsi_; } catch { }
            }
            get { 
                try { return this.InputDeskripsiVM.Text; } catch { return Deskripsi_; } }
        }

        private double TotalRp_;
        public virtual double TotalRp
        {
            set { this.OnSetProperty(ref TotalRp_, value); }
            get { return TotalRp_; }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputNamaVM.IsValid) throw new Exception("");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }
               
                return base.IsValid;
            }    
        }

        public override string Caption
        {
            get { return this.Nama; }
        }
        #endregion Properties

        public BankVM(PanelEnum panelenum) : this(null, panelenum, 1, null) { }
        public BankVM(Bank entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override void OnInitInput(Bank entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1) {
                this.InputNamaVM = new InputTextVM(new InputText("Nama Bank", "Cth : Bank BCA, Bank Mandiri, dll...","") { IsTitleCase = true });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "Deskripsikan bank anda...", "") { IsTitleCase = false });
            }
        }

        private async void OnGetSaldo()
        {
            var db = ((CoaService)Base.GetDb(nameof(Coa), this.DbName));
            this.TotalRp = await db.GetSaldoByReferensi(this.Id);
        }
    }
}
