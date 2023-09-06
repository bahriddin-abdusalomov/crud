using EntityCRUD.Data;
using EntityCRUD.Models.Staffs;
using EntityCRUD.Repositories.Travels;
using EntityCRUD.Repositories.Users;
using EntityCRUD.Repositories.Vehicles;

User user = new User()
{
    Id = 3,
    FirstName = "Ubaydullayev",
    LastName = "Jasurbek",
    PhoneNumber = "3332467890",
};

UserRepository userRepository = new UserRepository(new AppDbContext());
//Create 

//bool result = await userRepository.CreateAsync(user);

//Update

//user.FirstName = "Jamoliddin";
//user.LastName = "Xoshimov";
//bool result = await userRepository.UpdateAsync(user);

//Delete

//bool result = await userRepository.DeleteAsync(1);

//Console.WriteLine(result);

//Get by Id

//var getUser = await userRepository.GetByIdAsync(1);

//Console.WriteLine($"\nId: {getUser.Id}" + 
//    $"\nFirst Name: {getUser.FirstName}" + 
//    $"\nLast Name: {getUser.LastName}");


// Get All

//var getAllUser = await userRepository.GetAllAsync();
//foreach (var getUser in getAllUser)
//{
//    Console.WriteLine($"\nId: {getUser.Id}" +
//        $"\nFirst Name: {getUser.FirstName}" +
//        $"\nLast Name: {getUser.LastName}");
//}