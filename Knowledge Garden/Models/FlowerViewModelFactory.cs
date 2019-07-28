using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public static class FlowerViewModelFactory
    {
        public static FlowerDisplayViewModel CreateDisplayModel(Flower flower)
        {
            FlowerDisplayViewModel model = new FlowerDisplayViewModel
            {
                Problem = flower.Problem,
                Solution = flower.Solution,
                Title = flower.Title,
                OwnerUsername = flower.Owner.Username,
                Id = flower.Id,
                LastUpdateDate = flower.LastUpdateDate
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
                #region Build names list
                int size = flower.Attachments.Count;
                List<string> namesList = new List<string>();
                foreach (var attachment in flower.Attachments) namesList.Add(attachment.Name);
                model.AttachmentNames = namesList;
                #endregion
            }

            return model;
        }
    }
}