using System;
namespace TestsPets.DTO
{
    public record MedicalInfoDTO
        (
            bool Vaccinated,
            bool SpayedNeutered,
            bool Microchipped,
            bool SpecialNeeds,
            string HealthNotes
        );
}
