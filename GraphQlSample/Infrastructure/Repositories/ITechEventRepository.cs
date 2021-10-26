using GraphQlSample.Infrastructure.DBContext;
using GraphQlSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.Infrastructure.Repositories
{
  public  interface ITechEventRepository
    {

        Task<TechEventInfo[]> GetTechEventsAsync();
        Task<Participant[]> GetTechParticipantAsync();

        Task<EventParticipant[]> GetTechEventParticipantAsync();
        Task<TechEventInfo> GetTechEventByIdAsync(int id);
        Task<List<Participant>> GetParticipantInfoByEventIdAsync(int id);
        Task<TechEventInfo> AddTechEventAsync(NewTechEventRequest techEvent);

        Task<Participant> AddParticipantAsync(NewParticipantRequest techEvent);
        Task<TechEventInfo> UpdateTechEventAsync(TechEventInfo techEvent);
        Task<bool> DeleteTechEventAsync(TechEventInfo techEvent);
    }
}
