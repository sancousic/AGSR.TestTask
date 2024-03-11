using Microsoft.AspNetCore.Mvc;

namespace AGSR.Patients.Requests;

public record SearchByDateRequest([FromQuery]IEnumerable<string> date);