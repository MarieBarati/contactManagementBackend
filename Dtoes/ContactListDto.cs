using System.Collections.Generic;

namespace contactManagementBackend.Dtoes
{
    public class ContactListDto
    {
     public IEnumerable<ContactDto> ContactList{set; get;}
     public int TotalNumber {set; get;}
    }
}