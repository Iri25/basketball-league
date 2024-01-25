using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.validator
{
    class StudentValidator : IValidator<Student>
    {
        public void Validate(Student student)
        {
            string errors = "";

            int  id = student.Id;
            if(id.Equals(""))
                errors += "\n Invalid id student!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the student must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the student!";
            }

            string name = student.Name;
            if(name.Equals(""))
                errors += "\n Invalid name!";

            string school = student.School;
            if (school.Equals(""))
                errors += "\n Invalid school!";

           // if (!errors.Equals(""))
             //   throw new ValidationException(errors);
        }
    }
}

