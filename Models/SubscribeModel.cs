using System;
using System.ComponentModel.DataAnnotations;

namespace power_classroom.Models {

  public class Subscriber
  {
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
