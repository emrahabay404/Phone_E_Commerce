﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Core.Entities.Concrete
{
   public class UserOperationClaim : IEntity
   {
      [Key]
      public int Id { get; set; }
      public int UserId { get; set; }
      public int OperationClaimId { get; set; }
   }
}
