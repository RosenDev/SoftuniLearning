function recommendACar(requierments){
    const engines = [
          {power:90,volume:1800},
          {power:120,volume:2400},
          {power:200,volume:3500}
                    ]
        
        const recommededEngine = engines.find(e=>e.power>=requierments.power);
     const  recommendedCar = Object.assign(Object.create({}),
     {
      model:requierments.model,
      engine:recommededEngine,
      carriage:{type:requierments.carriage,color:requierments.color},
      wheels:new Array(4).fill(requierments.wheelsize%2!==0?requierments.wheelsize:requierments.wheelsize-1)
     })

     return recommendedCar;
}