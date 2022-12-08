# Projet-API-.NET

## Lancer le Projet
Le projet ne se lançant pas sur le profil https, il faut le forcer avec la commande suivante :   
- `dotnet run --launch-profile https`

### Quel est la diffèrence entre une classe abstraite et une interface ? 
Une classe abstraite est une classe dont toutes les méthodes n'ont pas été implémanté. Elle n'est donc pas instanciable et permet de factoriser du code. De plus une classe devient abstraite dès lors qu'elle contient un seul element abstrait en son sein.  

Une interface, est une sorte de classe abstraite dans laquelle aucune méthode ne sera implémanté, elles sont seulement déclarées, ce qui va permettre de définir un ensemble de service visible depuis l'exterieur (API)  

Entre Autre, une interface ne fait que décrire une liste de méthode, sans implémentation alors que la classe abstraite sert à factorisé du code.

```c#
abstract class Shape
{
    public abstract double GetArea();
}

class Circle : Shape
{
    double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : Shape
{
    double length;
    double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }
}
```
Si on se fit à a cette exemple de classe abstraite, la classe Shape qui est une classe abstraite définit une méthode GetArea(). Les classes Circle et Rectangle héritent donc de la classe Shape et surcharge la méthode en question pour fournir le calcul de l'aire.

### Expliquer pourquoi on a des portées dans les langages et à quoi ça sert ? Donner un exemple concret de pourquoi c’est utile.
Les niveaux d'accès en C# permettent de contrôler l'accessibilité des membres d'une classe et de protéger les données et les fonctionnalités de la classe, des classes qui ne devraient pas y accéder. Ils peuvent également être utilisés pour cacher les détails d'implémentation d'une classe derrière une interface publique.

## Retourner par la méthode GetAllHeroesAndPower()
```JSON
[
  {
    "id": 1,
    "name": "Hulk",
    "firstName": "Bruce",
    "lastName": "Banner",
    "place": "New York",
    "powers": [
      {
        "id": 1,
        "name": "Titan Vert",
        "description": "Force et résistance physique surhumaines quasi illimitées."
      }
    ]
  },
  {
    "id": 2,
    "name": "Spider-Man",
    "firstName": "Peter",
    "lastName": "Parker",
    "place": "New York",
    "powers": [
      {
        "id": 2,
        "name": "Spider-Sense",
        "description": "Il permet de détecter le danger avant qu'il ne se produise et avertit l'utilisateur en un rien de temps."
      }
    ]
  }
]
```