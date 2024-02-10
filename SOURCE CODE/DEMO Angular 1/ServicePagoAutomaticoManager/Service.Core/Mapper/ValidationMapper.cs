//using System;
//using System.Collections.Generic;
//using System.Linq;
//using FluentValidation;
//using FluentValidation.Results;
//using Service.Core.PersonaUnicaManager.DataContracts.DTO;
//using Infraestructure.DataPersistence.PersonaUnicaManager;

//namespace Service.Core.PersonaUnicaManager.Mapper
//{
//    internal enum ETipoIndividuo
//    {
//        Persona = 1,
//        Empresa = 2,
//        PersonaProspecto = 4,
//        EmpresaProspecto = 5
//    }

//    internal enum ETipoEmail
//    {
//        Particular = 1,
//        Laboral = 2,
//        Notes = 3
//    }

//    public interface IValidationMapper<T>
//    {
//        ValidationResult Validate(T instance);
//    }

//    public class ValidationMapper : AbstractValidator<IndividuoDTO>, IValidationMapper<IndividuoDTO>
//    {
//        public ValidationMapper(IPersonaRepository personaRepository)
//        {
//            RuleFor(individuo => individuo.UsuarioAlta).NotEmpty().WithMessage("Debe completar el usuario de alta.");
//            RuleFor(individuo => individuo.TipoIndividuo).NotNull().WithMessage("Debe seleccionar el tipo de individuo").NotEmpty().WithMessage("Debe seleccionar el tipo de individuo");
//            RuleFor(individuo => individuo.TipoSalutacion).NotNull().WithMessage("Debe seleccionar el tipo de salutacion").NotEmpty().WithMessage("Debe seleccionar el tipo de salutacion");
//            RuleFor(individuo => individuo.Direcciones).NotNull().When(individuo => individuo.TipoIndividuo.Codigo == Convert.ToInt16(ETipoIndividuo.Persona) || individuo.TipoIndividuo.Codigo == Convert.ToInt16(ETipoIndividuo.Empresa)).WithMessage("Debe ingresar una direccion").SetCollectionValidator(new DireccionValidator());
//            RuleFor(individuo => individuo.Emails).SetCollectionValidator(new EmailValidator());
//            RuleFor(individuo => individuo.Telefonos).SetCollectionValidator(new TelefonoValidator());
//            RuleFor(individuo => individuo.Persona).SetValidator(new PersonaValidator(personaRepository)).NotNull().When(x => x.TipoIndividuo.Codigo == 1 || x.TipoIndividuo.Codigo == 4).WithMessage("Debe ingresar una persona.");
//            RuleFor(individuo => individuo.Empresa).SetValidator(new EmpresaValidator()).NotNull().When(x => x.TipoIndividuo.Codigo == 2 || x.TipoIndividuo.Codigo == 5).WithMessage("Debe ingresar una empresa.");
//            RuleFor(individuo => individuo.Intermediarios).Must(ValidIntermediarios).WithMessage("Debe Ingresar un intermediario");
//            RuleFor(individuo => individuo.Impuestos).NotNull().When(x => x.TipoIndividuo.Codigo == 1 || x.TipoIndividuo.Codigo == 2).WithMessage("Debe completar los impuestos.").SetValidator(new ImpuestoValidator(personaRepository)).WithName("validaImpuesto");
//        }

//        private bool ValidImpuestos(IList<ImpuestoDTO> impuestos)
//        {

//            if (impuestos.Any(x => x != null))
//                return impuestos.Any(x => x.TipoImpuesto.Codigo == 1);
            
//            return false;
//        }

//        private bool ValidIntermediarios(IList<IntermediarioDTO> intermediarios)
//        {
//            if (intermediarios == null)
//                return false;

//            if (intermediarios.Count < 1)
//            {
//                return false;
//            }

//            return true;
//        }

//    }

//    public class DireccionValidator : AbstractValidator<DireccionDTO>
//    {
//        public DireccionValidator()
//        {
//            RuleFor(direccion => direccion.CodigoDireccion).NotEmpty().WithMessage("Debe completar el codigo de la direccion.");
//            RuleFor(direccion => direccion.Pais).NotEmpty().WithMessage("Debe completar el pais.");
//            RuleFor(direccion => direccion.Provincia).NotEmpty().WithMessage("Debe completar la provincia.");
//            RuleFor(direccion => direccion.Localidad).NotEmpty().WithMessage("Debe completar la localidad.");
//            RuleFor(direccion => direccion.TipoDireccion).NotEmpty().WithMessage("Debe completar el tipo de direccion.");
//        }
//    }

//    public class EmailValidator : AbstractValidator<EmailDTO>
//    {
//        public EmailValidator()
//        {
//            RuleFor(direccion => direccion.CodigoEmail).NotEmpty().WithMessage("Debe completar el codigo de email.");
//            RuleFor(direccion => direccion.Cuenta).NotEmpty().WithMessage("La cuenta de correo es obligatoria.").EmailAddress().WithMessage("La cuenta de correo no posee un formato valido.").When(x => x.TipoEmail.Codigo != 3);
//            RuleFor(direccion => direccion.CodigoEmail).NotNull().WithMessage("El numero de email es obligatorio.");
//            RuleFor(direccion => direccion.TipoEmail).NotNull().WithMessage("El tipo de email es obligatorio.");
//        }
//    }

//    public class ImpuestoValidator : AbstractValidator<ImpuestoDTO>
//    {
//        private readonly IPersonaRepository _personaRepository;

//        public ImpuestoValidator(IPersonaRepository personaRepository)
//        {
//            _personaRepository = personaRepository;

//            RuleFor(impuesto => impuesto.TipoImpuesto).NotNull().WithMessage("Debe completar el tipo de impuesto.").NotEmpty().WithMessage("Debe completar el tipo de impuesto.");
//            RuleFor(impuesto => impuesto.TipoCondicionFiscal).NotNull().WithMessage("Debe completar el tipo de condicion fiscal.").NotEmpty().WithMessage("Debe completar el tipo de condicion fiscal.");
//            RuleFor(impuesto => impuesto.Parte).NotNull().WithMessage("Debe completar el codigo de parte.");

//            RuleFor(impuesto => impuesto).Must(ValidImpuestoCondicionFiscal).WithMessage("Tipo de impuesto o Condición Fiscal Invalido.").WithName("Impuesto_CondicionFiscal");
//            RuleFor(impuesto => impuesto.Parte.Codigo).Must(ValidImpuestoParte).WithMessage("Codigo de Parte Invalido.").WithName("CodigoParte");
//        }

//        private bool ValidImpuestoCondicionFiscal(ImpuestoDTO impuesto)
//        {
//            if (impuesto.TipoImpuesto.Codigo != 0 && impuesto.TipoCondicionFiscal.Codigo != 0)
//            {
//                return _personaRepository.ValidImpuesto(impuesto.TipoImpuesto.Codigo, impuesto.TipoCondicionFiscal.Codigo);
//            }
//            return true;
//        }

//        private bool ValidImpuestoParte(Int16 codigoParte)
//        {
//            if (codigoParte != 0)
//            {
//                return _personaRepository.ValidParte(codigoParte);
//            }
//            return true;
//        }
//    }

//    public class TelefonoValidator : AbstractValidator<TelefonoDTO>
//    {
//        public TelefonoValidator()
//        {
//            RuleFor(telefono => telefono.CodigoTelefono).NotEmpty().WithMessage("Debe especificar el codigo de Telefono");
//        }
//    }

//    public class PersonaValidator : AbstractValidator<PersonaDTO>
//    {
//        private readonly IPersonaRepository _personaRepository;

//        public PersonaValidator(IPersonaRepository personaRepository)
//        {
//            _personaRepository = personaRepository;

//            RuleFor(persona => persona.Nombre).NotEmpty().WithMessage("El nombre del cliente es obligatorio.");
//            RuleFor(persona => persona.Apellido).NotEmpty().WithMessage("El apellido del cliente es obligatorio.");
//            RuleFor(persona => persona.NumeroDocumento).NotEmpty().WithMessage("El numero de documento del cliente es obligatorio.");
//            RuleFor(persona => persona.TipoDocumento).NotEmpty().WithMessage("El tipo de documento del cliente es obligatorio.");

//            RuleFor(persona => persona.EstadoCivil).NotEmpty().WithMessage("El estado civil es obligatorio.").NotNull().WithMessage("El estado civil es obligatorio.");
//            RuleFor(persona => persona.EstadoCivil.Codigo).Must(ValidEstadoCivil).WithMessage("Estado civil invalido.");
//        }

//        private bool ValidEstadoCivil(int estadoCivil)
//        {
//            if (estadoCivil != 0)
//            {
//                return _personaRepository.ValidEstadoCivil(estadoCivil);
//            }

//            return true;
//        }
//    }

//    public class EmpresaValidator : AbstractValidator<EmpresaDTO>
//    {
//        public EmpresaValidator()
//        {
//            RuleFor(empresa => empresa.CUIT).NotEmpty().WithMessage("El CUIT de la empresa es obligatorio.");
//            RuleFor(empresa => empresa.RazonSocial).NotEmpty().WithMessage("La razon social de la empresa es obligatorio.");
//            RuleFor(empresa => empresa.Actividad).NotEmpty().WithMessage("La Actividad de la empresa es obligatorio.");
//        }
//    }

//    public class EmpleadoValidationMapper : AbstractValidator<EmpleadoDTO>, IValidationMapper<EmpleadoDTO>
//    {
//        public EmpleadoValidationMapper()
//        {
//            RuleFor(empleado => empleado.FechaAlta).NotEmpty().WithMessage("No se ha especificado la fecha de alta");
//            RuleFor(empleado => empleado.CodigoUsuarioAlta).NotEmpty().WithMessage("No se ha especificado el usuario de alta");
//            RuleFor(empleado => empleado.IdIndividuo).NotEmpty().WithMessage("El ID del individuo asociado al empleado es obligatorio");
//            RuleFor(empleado => empleado.NumeroLegajo).NotEmpty().WithMessage("El numero de legajo es obligatorio");
//            RuleFor(empleado => empleado.Sucursal.Codigo).NotEmpty().WithMessage("El código de la sucursal es obligatorio");
//        }
//    }

//}

