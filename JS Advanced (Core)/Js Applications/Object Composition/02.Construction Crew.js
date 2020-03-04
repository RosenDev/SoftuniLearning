function hidratate(worker){
    let workerCopy = Object.assign(Object.create({}),worker)

        if(workerCopy.dizziness===true){
          workerCopy.levelOfHydrated += workerCopy.experience*workerCopy.weight*0.1
          workerCopy.dizziness = false;
        }

        return workerCopy;
}
