using UCSC.ASE.EbillService.EbillModules;

namespace UCSC.ASE.EbillService.EbillApplicationServices
{
    public interface IEbillApplicationService
    {
        bool SendEbillEmail(Ebill emailMessage);
    }
}
