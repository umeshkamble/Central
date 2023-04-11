
namespace Central.App.ViewModels
{
    public class CityVM : PanelVM<City>, ICity
    {
        #region Properties
        public override City Entity
        {
            set{
                var entity = value;
                base.Entity = entity;

                this.Nama = entity.Nama;
                this.Kode = entity.Kode;
                this.Deskripsi = entity.Deskripsi;
            }
            get => base.Entity;  
        }

        public string Nama { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }

        public override string Caption
        {
            get { return this.Nama; }
        }

        #endregion Properties

        public CityVM(City entity, PanelEnum panelenum, int no, ImageSource imagesource) : base(entity, panelenum, no, imagesource) { }
    }
}
