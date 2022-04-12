from abc import ABC, abstractmethod


class AbstractCoffeeSelect(ABC):

    @abstractmethod
    def grind_beans(self) -> bool:
        pass

    @abstractmethod
    def get_beans(self) -> int:
        pass

