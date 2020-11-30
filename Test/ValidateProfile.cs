using System;
using System.Collections.Generic;
using System.Text;
using GenericValidator;

namespace Test
{
    public class ValidateProfile : Profile
    {
        public ValidateProfile()
        {
            CreateConfig<Student>()
                .ForProperty(s => s.Age, opt => opt.Number(1, 20))
                .ForProperty(s=>s.Name, opt => opt.String(1,3));
            CreateConfig<Teacher>()
                .ForProperty(s => s.Age, opt => opt.Number(1, 50))
                .ForProperty(s=>s.Name, opt => opt.String(1,5));
        }
    }
}
