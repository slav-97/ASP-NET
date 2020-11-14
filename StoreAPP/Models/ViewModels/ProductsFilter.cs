using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreApp.Models.ViewModels
{

    public class SortList
    {
        public int Id { get; set; }
        public string SortType { get; set; }

        public SortList()
        {

        }

        public SortList(int id, string sortType)
        {
            Id = id;
            SortType = sortType;
        }
    }
    public class MemoryCapacity
    {
        public int Capacity { get; set; }
        public bool IsChecked { get; set; }
        public MemoryCapacity()
        {

        }

        public MemoryCapacity(int capacity, bool isChecked)
        {
            Capacity = capacity;
            IsChecked = isChecked;
        }
    }


    public class ManufacturersFilterItem
    {
        public string Manufacturer { get; set; }
        public bool IsChecked { get; set; }

        public ManufacturersFilterItem()
        {

        }
        public ManufacturersFilterItem(string manufacturer, bool isChacked)
        {
            Manufacturer = manufacturer;
            IsChecked = isChacked;
        }
    }

    public class MemoryTypeFilterItem
    {
        public string MemoryType { get; set; }
        public bool IsChecked { get; set; }

        public MemoryTypeFilterItem()
        {

        }
        public MemoryTypeFilterItem(string memoryType, bool isChacked)
        {
            MemoryType = memoryType;
            IsChecked = isChacked;
        }
    }

    public class ProductsFilter
    {

        public List<ManufacturersFilterItem> ManufacturersList { get; set; }

        public List<MemoryTypeFilterItem> MemoryTypeList { get; set; }

        public List<MemoryCapacity> MemoryCapacities { get; set; }

        private List<SortList> sortTypes;

        public int SelectedIndex { get; set; }
        public int IdPage = 1;

        public IEnumerable<SelectListItem> SortTypes
        {
            get { return new SelectList(sortTypes, "Id", "SortType"); }
        }


        public ProductsFilter()
        {
            sortTypes = new List<SortList>();
            sortTypes.Add(new SortList(1,"По цене"));
            sortTypes.Add(new SortList(2, "По производителю"));
            sortTypes.Add(new SortList(3, "По названию товара"));

            ManufacturersList = new List<ManufacturersFilterItem>();
            ManufacturersList.Add(new ManufacturersFilterItem("HyperX",false));
            ManufacturersList.Add(new ManufacturersFilterItem("Kingston", false));
            ManufacturersList.Add(new ManufacturersFilterItem("Lenovo", false));
            ManufacturersList.Add(new ManufacturersFilterItem("Cisco", false));
            ManufacturersList.Add(new ManufacturersFilterItem("HP", false));
            ManufacturersList.Add(new ManufacturersFilterItem("Thermaltake", false));
            ManufacturersList.Add(new ManufacturersFilterItem("AFOX", false));

            MemoryTypeList = new List<MemoryTypeFilterItem>();
            MemoryTypeList.Add(new MemoryTypeFilterItem("DDR", false));
            MemoryTypeList.Add(new MemoryTypeFilterItem("DDR2", false));
            MemoryTypeList.Add(new MemoryTypeFilterItem("DDR3", false));
            MemoryTypeList.Add(new MemoryTypeFilterItem("DDR4", false));

            MemoryCapacities = new List<MemoryCapacity>();
            MemoryCapacities.Add(new MemoryCapacity(1, false));
            MemoryCapacities.Add(new MemoryCapacity(2, false));
            MemoryCapacities.Add(new MemoryCapacity(4, false));
            MemoryCapacities.Add(new MemoryCapacity(8, false));
            MemoryCapacities.Add(new MemoryCapacity(16, false));
            MemoryCapacities.Add(new MemoryCapacity(32, false));
        }
    }
}