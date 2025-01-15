function GenerateSalt(SaltLength) {
    const karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    let salt = "";
    
    for (let i = 0; i < SaltLength; i++) {
        const randomIndex = Math.floor(Math.random() * karakterek.length);
        salt += karakterek[randomIndex];
    }
    
    return salt;
}