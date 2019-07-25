using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public static class FlowerViewModelFactory
    {
        public static FlowerDisplayViewModel CreateDisplayModel(Flower flower, string ownerUsername)
        {
            FlowerDisplayViewModel model = new FlowerDisplayViewModel
            {
                Problem = flower.Problem,
                Solution = flower.Solution,
                Title = flower.Title,
                OwnerUsername = ownerUsername
                // TODO: Get attachment files
            };
            return model;
        }
        
        public static FlowerAddOrEditViewModel CreateAddOrEditViewModel(Flower flower)
        {
            FlowerAddOrEditViewModel model = new FlowerAddOrEditViewModel
            {
                Problem = flower.Problem,
                Solution = flower.Solution,
                Title = flower.Title,
                Id = flower.Id
            };

            if (flower.Attachments != null)
            {
                #region Build names array
                int size = flower.Attachments.Length;
                string[] namesArray = new string[size];
                for (int i = 0; i < size; i++) namesArray[i] = flower.Attachments[i].Name;
                model.AttachmentNames = namesArray;
                #endregion
            }

            return model;
        }
    }
}