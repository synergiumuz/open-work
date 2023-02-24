using OpenWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.Admin
{
    public class DeleteCommentDto
    {
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; } = default!;
    }
}
