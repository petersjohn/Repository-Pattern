using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public class House
    {
        public House() { }

        public House(int yearBuilt, double acreage, string colorOfPaint, BuildingMaterial buildingMaterial, int numberOfBedrooms)
        {
            YearBuilt = yearBuilt;
            Acreage = acreage;
            ColorOfPaint = colorOfPaint;
            BuildingMaterial = buildingMaterial;
            Bedrooms = numberOfBedrooms;

        }
        public int YearBuilt { get; set; }
        public double Acreage { get; set; }
        public string ColorOfPaint { get; set; }
        public int Bedrooms { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }

    }
    public enum BuildingMaterial
    {
        Stone,
        Brick,
        Concrete,
        Vinyl,
        Wood,
        Plank,
        Stucco
    }
}
 
