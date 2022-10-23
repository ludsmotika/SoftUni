function modifyWorker(worker) {
    if (worker.dizziness === true) {
        worker.levelOfHydrated += 0.1 * worker.experience * worker.weight;
        worker.dizziness = false;
    }
    return worker;
}