請使用任意語言實作一個提供匯率轉換的 API    

● 此 API 需滿足以下條件  

  ○ 請使用 docker 包裝您的環境。若未使用 docker 或 docker-compose 不予給分。  
  
  ○ 需驗證使用者輸入的值。source、target 為字串，amount 輸入時無論有無千分位  
  皆可接受。例如「1,525」或「1525」皆可。  
    
  ○ 請新增 CurrencyExchangeService，並且使用依賴注入 (Dependency Injection,  
       DI) 以下靜態匯率資料。此資料若未依賴注入至 CurrencyExchangeService 不予給分。  
    
  ○ 轉換後的結果，請四捨五入到小數點第二位。  
  
  ○ 轉換後的結果，請加上半形逗點作為千分位表示，每三個位數一點。  
  
  ○ CurrencyExchangeService 必須包含（但不限於）以下測試案例：  
  
    ■ 若輸入的 source 或 target 系統並不提供時的案例  
    
    ■ 若輸入的金額為非數字或無法辨認時的案例  
    
    ■ 輸入的數字需四捨五入到小數點第二位，並請提供覆蓋有小數與沒有小數的多種案例  
    
  ○ 實作結果需區分不同 commit 加以說明。並以 GitHub、GitLab、Bitbucket 或其他  
    程式碼托管網站連結呈現。
