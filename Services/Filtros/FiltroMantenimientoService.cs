using System;
namespace ECOCEMProject;

public class FiltroMantenimientoService
{
    private readonly MyContext myContext;

    public FiltroMantenimientoService(MyContext myContext)
    {
        this.myContext = myContext;
    }

    public async Task<IEnumerable<RoturaEquipo>> GetRoturas(int? dia, int? mes, int? anno)
    {
        if (dia != null && mes != null && anno != null)
        {
            var roturasDia = myContext.RoturasEquipos.Where(r=>r.FechaId.Day == dia && r.FechaId.Month == mes && r.FechaId.Year == anno);
            return roturasDia;
        }
        if (dia == null && mes != null && anno != null)
        {
            var roturasMes = myContext.RoturasEquipos.Where(r=>r.FechaId.Month == mes && r.FechaId.Year == anno);
            return roturasMes;
        }
        if (dia == null && mes == null && anno != null)
        {
            var roturasAnno = myContext.RoturasEquipos.Where(r=>r.FechaId.Year == anno);
            return roturasAnno;
        }
        return null;
    }

    public async Task<IEnumerable<Reporte>> GetReportes(int? dia, int? mes, int? anno)
    {
        if (dia != null && mes != null && anno != null)
        {
            var reportesDia =  myContext.Reportes.Where(r=>r.FechaId.Day == dia && r.FechaId.Month == mes && r.FechaId.Year == anno);
            return reportesDia;
        }
        if (dia == null && mes != null && anno != null)
        {
            var reportesMes = myContext.Reportes.Where(r=>r.FechaId.Month == mes && r.FechaId.Year == anno);
            return reportesMes;
        }
        if (dia == null && mes == null && anno != null)
        {
            var reportesAnno = myContext.Reportes.Where(r=>r.FechaId.Year == anno);
            return reportesAnno;
        }
        return null;
    }

    public async Task<IEnumerable<Role>> GetRoles(int id)
    {
        List<Role>roles =new();
        var userRoles = myContext.UserRoles.Where(userRole => userRole.IdUser == id);
        var idRoles = userRoles.Select(userRole => userRole.IdRole).ToList();
        foreach(var idR in idRoles)
        {
            var role =  myContext.Roles.Find(idR);
            roles.Add(role);
        }
        return roles;
    }
}
