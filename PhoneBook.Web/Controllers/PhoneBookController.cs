using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneBook.Data.Entities;
using PhoneBook.Services.Services;
using PhoneBook.Web.Models.PhoneBookViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;
        private readonly IContactInformationService _contactInformationService;
        private readonly IInformationTypeService _informationTypeService;

        public PhoneBookController(IConfiguration configuration, IContactService contactService, IContactInformationService contactInformationService, IInformationTypeService informationTypeService)
        {
            _configuration = configuration;
            _contactService = contactService;
            _contactInformationService = contactInformationService;
            _informationTypeService = informationTypeService;
        }

        // Information Type

        [HttpGet]
        public async Task<IActionResult> InformationTypeIndex()
        {
            var informationTypes = await _informationTypeService.GetInformationTypesAsync();
            return View(informationTypes);
        }

        [HttpGet]
        public IActionResult CreateInformationType()
        {
            var informationTypeModel = new InformationTypeCreateDto();
            return View(informationTypeModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInformationType(InformationTypeCreateDto informationTypeModel)
        {
            var informationType = new InformationType
            {
                Name = informationTypeModel.Name
            };
            await _informationTypeService.AddInformationTypeAsync(informationType);
            return RedirectToAction(nameof(InformationTypeIndex));
        }

        [HttpGet]
        public async Task<IActionResult> EditInformationType(int informationTypeId)
        {
            var informationType = await _informationTypeService.GetInformationTypeAsync(informationTypeId);
            var informationTypeModel = new InformationTypeEditDto
            {
                UUID = informationType.UUID,
                Name = informationType.Name
            };
            return View(informationTypeModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditInformationType(InformationTypeEditDto informationTypeModel)
        {
            var informationType = await _informationTypeService.GetInformationTypeAsync(informationTypeModel.UUID);
            informationType.Name = informationTypeModel.Name;
            await _informationTypeService.UpdateInformationTypeAsync(informationType);
            return RedirectToAction(nameof(InformationTypeIndex));
        }

        public async Task<IActionResult> DeleteInformationType(int informationTypeId)
        {
            await _informationTypeService.DeleteInformationTypeAsync(informationTypeId);
            return RedirectToAction(nameof(InformationTypeIndex));
        }

        // Contact

        [HttpGet]
        public async Task<IActionResult> ContactIndex()
        {
            var contacts = await _contactService.GetContactsAsync();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> ViewContact(int contactId)
        {
            var contact = await _contactService.GetContactWithContactInformationsAsync(contactId);
            var viewContactModel = new ViewContactDto
            {
                UUID = contact.UUID,
                Name = contact.Name,
                Surname = contact.Surname,
                Company = contact.Company,
                ContactInformations = contact.ContactInformations
            };
            return View(viewContactModel);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            var contactModel = new ContactCreateDto();
            return View(contactModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactCreateDto contactModel)
        {
            var contact = new Contact
            {
                Name = contactModel.Name,
                Surname = contactModel.Surname,
                Company = contactModel.Company
            };
            await _contactService.AddContactAsync(contact);
            return RedirectToAction(nameof(ContactIndex));
        }

        [HttpGet]
        public async Task<IActionResult> EditContact(int contactId)
        {
            var contact = await _contactService.GetContactAsync(contactId);
            var contactModel = new ContactEditDto
            {
                UUID = contact.UUID,
                Name = contact.Name,
                Surname = contact.Surname,
                Company = contact.Company
            };
            return View(contactModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(ContactEditDto contactModel)
        {
            var contact = await _contactService.GetContactAsync(contactModel.UUID);
            contact.Name = contactModel.Name;
            contact.Surname = contactModel.Surname;
            contact.Company = contactModel.Company;
            await _contactService.UpdateContactAsync(contact);
            return RedirectToAction(nameof(ContactIndex));
        }

        public async Task<IActionResult> Deletecontact(int contactId)
        {
            await _contactService.DeleteContactAsync(contactId);
            return RedirectToAction(nameof(ContactIndex));
        }

        // Contact Information

        [HttpGet]
        public async Task<IActionResult> CreateContactInformation(int contactId)
        {
            var informationTypes = await _informationTypeService.GetInformationTypesAsync();
            if (informationTypes.Count() == 0)
            {
                TempData["message"] = "Add types before creating contact informations!";
                return RedirectToAction("ViewContact", new { contactId });   
            }
            var contact = await _contactService.GetContactAsync(contactId);
            var contactInformationModel = new ContactInformationCreateDto
            {
                ContactId = contactId,
                ContactName = contact.Name + " " + contact.Surname,
                InformationTypes = informationTypes
            };
            return View(contactInformationModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactInformation(ContactInformationCreateDto contactInformationModel)
        {
            var contactInformation = new ContactInformation
            {
                ContactId = contactInformationModel.ContactId,
                Content = contactInformationModel.Content,
                InformationTypeId = contactInformationModel.InformationTypeId
            };
            await _contactInformationService.AddContactInformationAsync(contactInformation); 
            return RedirectToAction("ViewContact", new { contactInformation.ContactId });
        }

        [HttpGet]
        public async Task<IActionResult> EditContactInformation(int contactInformationId)
        {
            var contactInformation = await _contactInformationService.GetContactInformationWithTypeAsync(contactInformationId);
            var contactInformationModel = new ContactInformationEditDto
            {
                UUID = contactInformation.UUID,
                Content = contactInformation.Content,
                ContactId = contactInformation.ContactId,
                ContactName = contactInformation.Contact.Name + " " + contactInformation.Contact.Surname,
                InformationTypeId = contactInformation.InformationTypeId,
                InformationTypes = await _informationTypeService.GetInformationTypesAsync()
            };
            return View(contactInformationModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditContactInformation(ContactInformationEditDto contactInformationModel)
        {
            var contactInformation = await _contactInformationService.GetContactInformationWithTypeAsync(contactInformationModel.UUID);
            contactInformation.Content = contactInformationModel.Content;
            contactInformation.InformationTypeId = contactInformationModel.InformationTypeId;
            await _contactInformationService.UpdateContactInformationAsync(contactInformation);
            return RedirectToAction("ViewContact", new { contactInformation.ContactId });
        }

        public async Task<IActionResult> DeleteContactInformation(int contactInformationId)
        {
            var contactId = (await _contactInformationService.GetContactInformationAsync(contactInformationId)).ContactId;
            await _contactInformationService.DeleteContactInformationAsync(contactInformationId);
            return RedirectToAction("ViewContact", new { contactId });
        }
    }
}
