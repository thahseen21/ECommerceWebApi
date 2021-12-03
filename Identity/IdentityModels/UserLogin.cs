using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Identity.IdentityModels
{
    [Keyless]
    public partial class UserLogin : IdentityUserLogin<Guid>
    {

    }
}
