using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.validator
{
    class PlayerValidator : IValidator<Player>
    {
        public void Validate(Player player)
        {
            string errors = "";

            long id = player.Id;
            if (id.Equals("") || id <= 0)
                errors += "\n Invalid id player!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the player must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the player!";
            }

            string name = player.Name;
            if (name.Equals(""))
                errors += "\n Invalid name!";

            string school = player.School;
            if (school.Equals(""))
                errors += "\n Invalid school!";

         //   if (!errors.Equals(""))
              //  throw new ValidationException(errors);
        }
    }
}
