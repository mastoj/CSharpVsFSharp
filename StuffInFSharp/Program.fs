// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module User = 
    open System

    type Subscription = Subscription of string
    type ActiveUser = {Name: string; Subscriptions: Subscription list}
    type DeletedUser = {Name: string; DeletionDate: DateTime}

    type User = 
    | ActiveUser of ActiveUser
    | DeletedUser of DeletedUser

    let delete activeUser = 
        let {Name = name; Subscriptions = _} = activeUser
        {Name = name; DeletionDate = DateTime.UtcNow}

    let undelete deletedUser = 
        let {Name = name; DeletionDate = _} = deletedUser
        {Name = name; Subscriptions = []}

    let addSubscription activeUser newSub = 
        {activeUser with Subscriptions = newSub::activeUser.Subscriptions}

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
