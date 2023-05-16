using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class SayfaRepository : EfRepositoryBase<AracIhaleContext, Sayfa>, ISayfaRepository
	{
		private readonly AracIhaleContext _context;
		public SayfaRepository()
		{

		}
		public SayfaRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Sayfa>> RoleGoreSayfaYetkileriniGetir(int uyeRol)
		{
			return (from s in _context.RolYetki
				join sy in _context.Sayfa on s.SayfaId equals sy.SayfaId
				where s.RolId == uyeRol
				select new Sayfa()
				{
					SayfaId = sy.SayfaId,
					SayfaAdi = sy.SayfaAdi,
					SayfaLink = sy.SayfaLink
				}).ToList();
		}
	}
}
