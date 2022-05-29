export const UserIsLoggedIn = () => {
  return localStorage.getItem('userInfo') != null;
};
