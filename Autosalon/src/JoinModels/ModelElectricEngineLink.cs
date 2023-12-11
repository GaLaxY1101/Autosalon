using Autosalon.src.models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Autosalon.src.models.Model;

namespace Autosalon.src.JoinModels
{
    public class ModelElectricEngineLink
    {
        public int ModelId { get; set; }   
        public virtual Model? Model {  get; set; }
        public int ElectricEngineId { get; set; }
        public virtual ElectricEngine? ElectricEngine { get; set; }

        ModelElectricEngineLink() { }
        ModelElectricEngineLink(int modelId, Model model, int electricEngineId, ElectricEngine engine)
        {
            ModelId = modelId;
            Model = model;
            ElectricEngineId = electricEngineId;
            ElectricEngine = engine;
        }
    }
}
