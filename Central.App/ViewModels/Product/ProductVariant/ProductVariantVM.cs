using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Central.App.ViewModels
{
    public class ProductVariantVM : PanelVM<ProductVariant>
    {
        #region Properties
        public override ProductVariant Entity 
        {
            set {
                if (value is null) return;
                var entity = value;
                base.Entity = entity;
                
                this.VariantItems = entity.VariantItems;
                this.Qty = entity.Qty;
                this.RateEceran = entity.RateEceran;
                this.RateApp = entity.RateApp;
                this.RateModal = entity.RateModal;
                this.NoBarcode = entity.NoBarcode;
                this.Weight = entity.Weight;
                this.Dimension = entity.Dimension;
                this.UnitPrev = entity.UnitPrev;
            }
            get {
                var entity = base.Entity;
                entity.VariantItems = this.VariantItems;
                entity.Qty = this.Qty;
                entity.RateEceran = this.RateEceran;
                entity.RateApp = this.RateApp;
                entity.RateModal = this.RateModal;
                entity.NoBarcode = this.NoBarcode;
                entity.Weight = this.Weight;
                entity.Dimension = this.Dimension;
                return entity;
            }
        }

        public InputTextVM InputVariantVM { get; set; }
        public InputTextVM InputQtyVM { get; set; }

        public InputRateVM InputRateEceranVM { get; set; }
        public InputRateVM InputRateAppVM { get; set; }
        public InputRateVM InputRateModalVM { get; set; }
        
        public InputTextVM InputNoBarcodeVM { get; set; }
        public InputTextVM InputWeightVM { get; set; }
        public InputTextVM InputDimensionPVM { get; set; }
        public InputTextVM InputDimensionLVM { get; set; }
        public InputTextVM InputDimensionTVM { get; set; }

        private List<string> VariantItems_;
        public List<string> VariantItems
        {
            set {
                if (value is null) return;

                VariantItems_ = value;
                try { this.InputVariantVM.Text = Base.ToString(VariantItems_, ','); } catch { }
            }
            get { try { return Base.ToList(this.InputVariantVM.Text.Trim(), ','); } catch { return VariantItems_; } }
        }

        private double Qty_;
        public double Qty
        {
            set {
                Qty_ = value;
                try { this.InputQtyVM.Text = Qty_.ToString(); } catch { }
            }
            get { try { return Base.ToDouble(this.InputQtyVM.Text); } catch { return Qty_; } }
        }

        private Rate RateEceran_;
        public Rate RateEceran
        {
            set {
                if (value is null) return;

                RateEceran_ = value;
                try { this.InputRateEceranVM.Rate = RateEceran_; } catch { }
            }
            get { try { return this.InputRateEceranVM.Rate; } catch { return RateEceran_; } }
        }

        private Rate RateApp_;
        public Rate RateApp
        {
            set
            {
                if (value is null) return;

                RateApp_ = value;
                try { this.InputRateAppVM.Rate = RateApp_; } catch { }
            }
            get { try { return this.InputRateAppVM.Rate; } catch { return RateApp_; } }
        }

        private Rate RateModal_;
        public Rate RateModal
        {
            set
            {
                if (value is null) return;

                RateModal_ = value;
                try { this.InputRateModalVM.Rate = RateModal_; } catch { }
            }
            get { try { return this.InputRateModalVM.Rate; } catch { return RateModal_; } }
        }

        private string NoBarcode_;
        public virtual string NoBarcode
        {
            set {
                NoBarcode_ = value;
                try { this.InputNoBarcodeVM.Text = NoBarcode_; } catch { }
            }
            get { try { return this.InputNoBarcodeVM.Text; } catch { return NoBarcode_; } }
        }

        private double Weight_;
        public double Weight
        {
            set {
                Weight_ = value;
                try { this.InputWeightVM.Text = Weight_.ToString(); } catch { }
            }
            get { try { return Base.ToDouble(this.InputWeightVM.Text); } catch { return Weight_; } }
        }

        private Dimension Dimension_;
        public Dimension Dimension
        {
            set {
                if (value is null) return;
                Dimension_ = value;

                try {
                    this.InputDimensionPVM.Text = Dimension_.P.ToString();
                    this.InputDimensionLVM.Text = Dimension_.L.ToString();
                    this.InputDimensionTVM.Text = Dimension_.T.ToString();
                }
                catch { }
            }
            get {
                try {
                    return new Dimension() {
                        P = Base.ToDouble(this.InputDimensionPVM.Text.Trim()),
                        L = Base.ToDouble(this.InputDimensionLVM.Text.Trim()),
                        T = Base.ToDouble(this.InputDimensionTVM.Text.Trim())
                    };
                }
                catch { return Dimension_; }
            }
        }

        private string UnitPrev { get; set; }
        public override string Caption
        {
            get { return this.UnitPrev; }
        }

        public override bool IsValid 
        {
            get {
                try {
                    if (!this.InputVariantVM.IsValid) throw new Exception("");
                    else if (!this.InputQtyVM.IsValid) throw new Exception("");
                }
                catch (Exception ex) {
                    if (ex.Message != "") this.OnLog(ex);
                    return false;
                }

                return base.IsValid;
            }
        }
        #endregion Properties

        public ProductVariantVM(ProductVariant entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity,panelenum, no, imagesource) { }
        protected override void OnInitInput(ProductVariant entity, PanelEnum panelenum)
        {
            base.OnInitInput(entity, panelenum);

            if (panelenum == PanelEnum.Edit1) {
                this.InputVariantVM = new InputTextVM(new InputText("Nama Varian", "Satuan", "", IconFont.StickyNote, TextEnum.Text));
                this.InputQtyVM = new InputTextVM(new InputText("Qty (Kemasan)", "Qty Kemasan", "", IconFont.Calculator, TextEnum.NumberDecimal));
                
                this.InputRateEceranVM = new InputRateVM(new InputRate("H. Eceran (1)", "Rp.", "", IconFont.Calculator,null));
                this.InputRateAppVM = new InputRateVM(new InputRate("H. Aplikasi (2)", "Rp.", "", IconFont.Calculator, null));
                this.InputRateModalVM = new InputRateVM(new InputRate("H. Modal", "Rp.", "", IconFont.Calculator, null));
                
                this.InputNoBarcodeVM = new InputTextVM(new InputText("No. Barcode", "Ketik/Scan barcode...", "", IconFont.Barcode, TextEnum.Text));
                this.InputWeightVM = new InputTextVM(new InputText("Berat", "Kg", "", IconFont.Calculator, TextEnum.NumberDecimal));
                this.InputDimensionPVM = new InputTextVM(new InputText("", "", "", "", TextEnum.NumberDecimal));
                this.InputDimensionLVM = new InputTextVM(new InputText("", "", "", "", TextEnum.NumberDecimal));
                this.InputDimensionTVM = new InputTextVM(new InputText("", "", "", "", TextEnum.NumberDecimal));

                this.InputVariantVM.IsReadOnly = true;
                this.InputVariantVM.FontAttributes = FontAttributes.Bold;
                this.InputVariantVM.TextAlignment = this.InputNoBarcodeVM.TextAlignment = TextAlignment.End;
            }
        }



    }
}
