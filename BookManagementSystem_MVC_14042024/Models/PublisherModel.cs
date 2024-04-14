using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem_MVC_14042024.Models
{
    public class PublisherModel
    {
        public int PublisherId { get; set; }
        public string RegistrationId { get; set; }
        public string PublisherName { get; set; }

        public static PublisherEntity Convert(PublisherModel model)
        {
            return new PublisherEntity()
            {
                PublisherId = model.PublisherId,
                PublisherName = model.PublisherName,
                RegistrationId = model.RegistrationId
            };
        }

        public static PublisherModel Convert(PublisherEntity entity)
        {
            return new PublisherModel()
            {
                PublisherId = entity.PublisherId,
                PublisherName = entity.PublisherName,
                RegistrationId = entity.RegistrationId
            };
        }
    }
}