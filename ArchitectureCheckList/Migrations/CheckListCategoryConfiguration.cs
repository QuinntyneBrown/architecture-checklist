using System.Data.Entity.Migrations;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Models;
using ArchitectureCheckList.Services;

namespace ArchitectureCheckList.Migrations
{
    public class CheckListCategoryConfiguration
    {
        public static void Seed(DataContext context) {

            context.SaveChanges();
        }
    }
}
