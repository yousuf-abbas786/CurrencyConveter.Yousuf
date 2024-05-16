using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.ExtAPIEntities
{
    public class ExtMatches
    {
        public long id { get; set; }
        public int source { get; set; }
        public DateTime matchDate { get; set; }
        public int sportId { get; set; }
        public long leagueId { get; set; }
        public long homeId { get; set; }
        public long awayId { get; set; }
        public int isActive { get; set; }
        public int isNew { get; set; }
        public int isMapped { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime updateDate { get; set; } = DateTime.Now.ToUniversalTime();
        public long internalId { get; set; }
        public string? sourceProvidedID { get; set; }
        public int isVisible { get; set; }
        public long mappedBy { get; set; }
        public long updatedBy { get; set; }
        public int isFinished { get; set; }
        public DateTime? finishDate { get; set; }
        public int? isEnded { get; set; }
        public int? isAbandoned { get; set; }
        public int isUpdateSent { get; set; }
        public int isInsertSent { get; set; }
        public DateTime? calUpdateDate { get; set; }
        public long alert { get; set; }
        public long uq_matchId { get; set; }
        public DateTime uq_matchDate { get; set; }
    }
}
