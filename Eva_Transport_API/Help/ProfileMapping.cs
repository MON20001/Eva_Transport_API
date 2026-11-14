using AutoMapper;
using Eva_Transport_API.DTOs.BusMapper;
using Eva_Transport_API.DTOs.FunctionalMapper;
using Eva_Transport_API.DTOs.FunctionalMapper.EmployeeMapper;
using Eva_Transport_API.DTOs.TruckMapper;
using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;

namespace Eva_Transport_API.Help
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            #region Company
            CreateMap<CreateCompanyDTO, Company>();
            #endregion

            #region Employee
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();
            CreateMap<Employee, ReturnEmployeeDTO>();
            CreateMap<Company, ReturnCompanyEmployeeDTO>();
            CreateMap<BusTrip, ReturnBusTripEmployeeDTO>();
            #endregion

            #region Bus
            //Main Bus
            CreateMap<CreateBusDTO, Bus>();
            CreateMap<UpdateBusDTO, Bus>();
            CreateMap<Bus, ReturnBusDTO>();
            CreateMap<Company, ReturnCompanyBusDTO>();
            CreateMap<BusDriver, ReturnBusDriverBusDTO>();
            CreateMap<BusMaintenanceRequest, ReturnReportsBusDTO>();
            CreateMap<BusTrip, ReturnBusTripBusDTO>();
            //Driver Bus
            CreateMap<CreateBusDriverDTO, BusDriver>();
            CreateMap<UpdateBusDriverDTO, BusDriver>();
            CreateMap<BusDriver, ReturnBusDriverDTO>();
            CreateMap<Bus, ReturnBusOfBusDriverDTO>();
            //Bus Trip
            CreateMap<CreateBusTripDTO,BusTrip>();
            CreateMap<UpdateBusTripDTO,BusTrip>();
            CreateMap<BusTrip, ReturnBusTripDTO>();
            CreateMap<Bus, ReturnBusOfBusTripDTO>();
            CreateMap<Employee, ReturnEmployeeBusTripDTO>();
            //Bus Reports
            CreateMap<CreateBusReportDTO, BusMaintenanceRequest>();
            CreateMap<UpdateBusReportDTO, BusMaintenanceRequest>();
            CreateMap<ReturnBusReportDTO, BusMaintenanceRequest>();
            CreateMap<ReturnBusOfBusReportDTO, Bus>();
            #endregion

            #region Truck
            //Main Truck
            CreateMap<CreateTruckDTO, Truck>();
            CreateMap<UpdateTruckDTO, Truck>();
            CreateMap<Truck, ReturnTruckDTO>();
            CreateMap<Company, ReturnCompanyTruckDTO>();
            CreateMap<TruckDriver, ReturnTruckDriverOfTruckDTO>();
            CreateMap<TruckMaintenanceRequest, ReturnReportsTruckDTO>();
            CreateMap<TruckTrip, ReturnTruckTripDTO>();
            //Truck Driver
            CreateMap<CreateTruckDriverDTO, TruckDriver>();
            CreateMap<UpdateTruckDriverDTO, TruckDriver>();
            CreateMap<TruckDriver, ReturnTruckDriverDTO>();
            CreateMap<Truck, ReturnTruckOfTruckDriverDTO>();
            //Truck Trip
            CreateMap<CreateTruckTripDTO, TruckTrip>();
            CreateMap<UpdateTruckTripDTO, TruckTrip>();
            CreateMap<TruckTrip, ReturnTruckTripDTO>();
            CreateMap<Truck, ReturnTruckOfTruckTripDTO>();
            //Bus Reports
            CreateMap<CreateTruckReportDTO, TruckMaintenanceRequest>();
            CreateMap<UpdateTruckReportDTO, TruckMaintenanceRequest>();
            CreateMap<ReturnTruckReportDTO, TruckMaintenanceRequest>();
            CreateMap<ReturnTruckOfTruckReportDTO, Truck>();
            #endregion

        }
    }
}
