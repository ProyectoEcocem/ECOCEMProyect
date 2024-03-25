using Microsoft.EntityFrameworkCore;
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
        return null!;
    }

    public async Task<IEnumerable<Reporte>> GetReportes(int? dia, int? mes, int? anno,int equipoId)
    {
        if(equipoId == 0){
            if (dia != null && mes != null && anno != null)
            {
                var reportesDia =   myContext.Reportes.Where(r=>r.FechaId.Day == dia && r.FechaId.Month == mes && r.FechaId.Year == anno);
                return reportesDia;
            }
            if (dia == null && mes != null && anno != null)
            {
                var reportesMes = myContext.Reportes.Where(r=>r.FechaId.Month == mes && r.FechaId.Year == anno);
                return reportesMes;
            }
            if (dia == null && mes == null && anno != null)
            {
                var reportesAnno = myContext.Reportes.Where(r=>r.FechaId.Year == anno );
                return reportesAnno;
            }
        }
        else{

            if (dia != null && mes != null && anno != null)
            {
                var reportesDia =   myContext.Reportes.Where(r=>r.FechaId.Day == dia && r.FechaId.Month == mes && r.FechaId.Year == anno && r.EquipoId==equipoId);
                return reportesDia;
            }
            if (dia == null && mes != null && anno != null)
            {
                var reportesMes = myContext.Reportes.Where(r=>r.FechaId.Month == mes && r.FechaId.Year == anno && r.EquipoId==equipoId);
                return reportesMes;
            }
            if (dia == null && mes == null && anno != null)
            {
                var reportesAnno = myContext.Reportes.Where(r=>r.FechaId.Year == anno && r.EquipoId==equipoId);
                return reportesAnno;
            }

        }
        return null!;
    }

    public async Task<IEnumerable<Role>> GetRoles(int id)
    {
        List<Role>roles =new();
        var userRoles = myContext.UserRoles.Where(userRole => userRole.IdUser == id);
        var idRoles = userRoles.Select(userRole => userRole.IdRole).ToList();
        
        foreach(var idR in idRoles)
        {
            var role = await myContext.Roles.FindAsync(idR);
            roles.Add(role!);
        }
        return roles;
    }

    public async Task<IEnumerable<int>> GetEquipos(string TipoE)
    {
        var result = await myContext.Equipos.Join(myContext.TiposEquipos,
                                                equipo =>equipo.TipoEId,
                                                tipoEquipo => tipoEquipo.TipoEId,
                                                (equipo,tipoEquipo)=> new { EquipoId = equipo.EquipoId, TipoE = tipoEquipo.TipoE })
                                                .Where(x => x.TipoE == TipoE)
                                                .Select(x => x.EquipoId)
                                                .ToListAsync();
                                                

        return result;
    }
    
    public async Task<IEnumerable<CargaSiloResultado>> ObtenerCargaSiloJoin()
{
    var resultado = await myContext.Cargas
        .Join(myContext.Silos,
              carga => carga.SiloId,
              silo => silo.SiloId,
              (carga, silo) => new CargaSiloResultado
              {
                NoSilo = silo.NoSilo,
                TipoCementoId = carga.TipoCementoId,
                FechaCargaId = carga.FechaCargaId,
                SedeId = carga.SedeId,
                EntidadCompradoraId = carga.EntidadCompradoraId
              })
        .ToListAsync();

    return resultado;
}

    public double GetHoras(int equipoId)
    {
        
        double horaTotal = 0;
        var reporte = myContext.Reportes.Where(r => r.EquipoId == equipoId);

        foreach(var h in reporte)
        {
            horaTotal += h.TiempoOPeracionReal;
        }

        return horaTotal;
    }

    /*public async Task<IEnumerable<Role>> GetAllRoles()
    {
        var roles = myContext.Users.Include(e => e.Roles).ToList();
        return roles;
    }*/

}
