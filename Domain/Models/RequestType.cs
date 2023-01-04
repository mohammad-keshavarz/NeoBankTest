using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public enum RequestType
{
	Post = 1,
	Get,
	Patch,
	Delete,
	Update,
	Put
}