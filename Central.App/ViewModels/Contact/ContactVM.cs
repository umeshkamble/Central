

using Contact = Central.Library.Contact;

namespace Central.App.ViewModels
{
    public class ContactVM<C> : PanelVM<C> where C : Contact
    {
        #region Properties
        public override C Entity 
        {
            set {
                if (value is null) return;

                var entity = value;
                base.Entity = entity;
                this.Nama = entity.Nama;
                this.Email = entity.Email;
                this.Deskripsi = entity.Deskripsi;
                this.Addresss = entity.Addresss;
                this.Phones = entity.Phones;

                this.Kota = entity.AddressDef.Kota;
                this.NoTlp = entity.PhoneDef.NoTlp;

                /*
                var tasks = new List<Task>();
                tasks.Add(Task.Run(() => base.Entity = entity));
                tasks.Add(Task.Run(() => this.Nama = entity.Nama));
                tasks.Add(Task.Run(() => this.Email = entity.Email));
                tasks.Add(Task.Run(() => this.Deskripsi = entity.Deskripsi));
                tasks.Add(Task.Run(() => this.Addresss = entity.Addresss));
                tasks.Add(Task.Run(() => this.Phones = entity.Phones));
                tasks.Add(Task.Run(() => this.Kota = entity.AddressDef.Kota));
                tasks.Add(Task.Run(() => this.NoTlp = entity.PhoneDef.NoTlp));
                
                var t = Task.WhenAll(tasks);
                try { t.Wait(); } catch { }
                */
            }
            get {
                var entity = base.Entity;
                entity.Nama = this.Nama;
                entity.Email = this.Email;
                entity.Deskripsi = this.Deskripsi;
                entity.Addresss = this.Addresss;
                entity.Phones = this.Phones;
                return entity;
            }
        }

        public InputTextVM InputNamaVM { get; set; }
        public InputTextVM InputEmailVM { get; set; }
        public InputTextVM InputDeskripsiVM { get; set; }
        
        public MenuListVM AddressMenuListVM { get; set; }
        public AddressListVM AddressListVM { get; set; }
        
        public MenuListVM PhoneMenuListVM { get; set; }
        public PhoneListVM PhoneListVM { get; set; }

        private string Nama_;
        public virtual string Nama
        {
            set {
                Nama_ = value;
                try { this.InputNamaVM.Text = Nama_; } catch { }

                this.OnPropertyChanged();
            }
            get { try { return this.InputNamaVM.Text; } catch { return Nama_; } }
        }

        private string Email_;
        public virtual string Email
        {
            set {
                Email_ = value;
                try { this.InputEmailVM.Text = Email_; } catch { }

                this.OnPropertyChanged();
            }
            get { try { return this.InputEmailVM.Text; } catch { return Email_; } }
        }

        private string Deskripsi_;
        public virtual string Deskripsi
        {
            set {
                Deskripsi_ = value;
                try { this.InputDeskripsiVM.Text = Deskripsi_; } catch { }

                this.OnPropertyChanged();
            }
            get { 
                try { return this.InputDeskripsiVM.Text; } catch { return Deskripsi_; } }
        }

        private string Kota_;
        public virtual string Kota
        {
            set { this.OnSetProperty(ref Kota_, value); }
            get { return Kota_; }
        }

        private string NoTlp_;
        public virtual string NoTlp
        {
            set { this.OnSetProperty(ref NoTlp_, value); }
            get { return NoTlp_; }
        }

        private List<Address> Addresss_;
        public virtual List<Address> Addresss
        {
            set {
                if (value is null) return;

                Addresss_ = value;
                try { this.AddressListVM.InsertCommand.Execute(Addresss_); } catch { }
            
            }
            get { try { return this.AddressListVM.Entitys; } catch { return Addresss_; } }
        }

        private List<Phone> Phones_;
        public virtual List<Phone> Phones
        {
            set {
                if (value is null) return;

                Phones_ = value;
                try { this.PhoneListVM.InsertCommand.Execute(Phones_); } catch { }
            }
            get { try { return this.PhoneListVM.Entitys; } catch { return Phones_; } }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputNamaVM.IsValid) throw new Exception("");
                    else if (this.Addresss.Count == 0) throw new Exception("Silahkan isikan daftar alamat terlebih dahulu !");
                    else if (this.Phones.Count == 0) throw new Exception("Silahkan isikan daftar telepon terlebih dahulu !");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnAlert(ex);
                    return false;
                }
               
                return base.IsValid;
            }    
        }

        public override string Caption => this.Nama;
        #endregion Properties

        public ContactVM(C entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
        protected override void OnInitInput(C entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);
            if (panelenum == PanelEnum.Edit1){
                this.InputNamaVM = new InputTextVM(new InputText("Nama", "Nama kontak", "") { IsTitleCase = true });
                this.InputDeskripsiVM = new InputTextVM(new InputText("Deskripsi", "Deskripsikan kontak ini...", "") { IsTitleCase = false });
                this.InputEmailVM = new InputTextVM(new InputText("Email", "Masukkan email utk kontak ini...", "") { IsTitleCase = false });
                this.AddressListVM = new AddressListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None, PanelEnum.Edit1);
                this.PhoneListVM = new PhoneListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None, PanelEnum.Edit1);

                this.AddressMenuListVM = new MenuListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None);
                this.AddressMenuListVM.MenuSelectedChanged += this.OnMenuSelect;
                this.AddressMenuListVM.InsertCommand.Execute(new List<Menu> {
                    new Menu(MenuEnum.AddAddress, IconFont.Plus)
                });

                this.PhoneMenuListVM = new MenuListVM(new List<TemplateEnum>() { TemplateEnum.T1 }, SelectionEnum.None);
                this.PhoneMenuListVM.MenuSelectedChanged += this.OnMenuSelect;
                this.PhoneMenuListVM.InsertCommand.Execute(new List<Menu> {
                    new Menu(MenuEnum.AddPhone, IconFont.Plus)
                });
            }
            
        }

        public override void OnMenuSelect(MenuEnum menu)
        {
            switch (menu) {
                case MenuEnum.AddAddress: {
                        var entity = new Address();
                        this.AddressListVM.InsertOneCommand.Execute(entity);
                        break; 
                    }
                case MenuEnum.AddPhone: {
                        var entity = new Phone();
                        this.PhoneListVM.InsertOneCommand.Execute(entity);
                        break;
                    }
                default: base.OnMenuSelect(menu);break;
            }
        }

    }
}
