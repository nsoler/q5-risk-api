using q5_risk_api.Enums;
namespace q5_risk_api.Models;

public class EvaluatationResultModel
{
    public Guid EvaluationResultUuid { get; set; }
    
    public double Score { get; set; }
    
    public RiskStatus Status { get; set; }
}